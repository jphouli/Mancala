using System.Net.Sockets;

namespace Mancala
{
    /// <summary>
    /// Filename: frmMain.cs
    /// Part of Project: Mancala
    /// 
    /// File Purpose: The client-side portion of the Mancala game.
    /// 
    /// Program Purpose: This program will setup the client
    /// portion of the Mancala game, connect with the server program,
    /// and play out the game of Mancala while sending the game data
    /// to the server.
    /// </summary>
    public partial class frmMain : Form
    {
        //VARIABLES
        TcpClient? client; // Client
        NetworkStream ?clientNetStream; // Client net stream
        BinaryWriter ?clientNetWriter; // Client net writer
        BinaryReader ?clientNetReader; // Client net reader
        public Task ?getServerDataThread; // Server data task
        CancellationTokenSource ?clientCTS; // Cancel token for the server data task
        Button[] ?buttons; // Buttons array for the spaces of the board
        char playerNumber; // Determines which player the server is
        char whoGoesFirst; // Determines who's going first
        bool currentTurn; // Boolean value for the current turn

        /// <summary>
        /// This is the default constructor for the frmMain class
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loading event for the program. This will setup the buttons into the array and
        /// give them a custom event for their click.
        /// </summary>
        /// <param name="sender">Identifies the particular control that raised the load event</param>
        /// <param name="e">Holds the EventArgs object sent to the routine</param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            buttons = [ btnOne, btnTwo, btnThree, btnFour, btnFive, btnPlayerTwo, btnSix, btnSeven, btnEight, btnNine, btnTen, btnPlayerOne];
            foreach (Button button in buttons)
            {
                button.Click += buttonMoveSpace_Click;
            }
        }

        /// <summary>
        /// Click handler for when the user wants to connect to a server.
        /// This will change the settings of the buttons/groupboxes to stop the user from changing their settings after connecting to the server.
        /// The listbox that will hold all of the I/O from the client will be cleared.
        /// The client will attempt to connect to the server, if an error occurs then the listbox will be updated with the error message.
        /// </summary>
        /// <param name="sender">Identifies the particular control that raised the click event</param>
        /// <param name="e">Holds the EventArgs object sent to the routine</param>
        private void btnStartClient_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeSettings();
                ControlInvokeAction<ListBox>(lstGameLog, lst => lst.Items.Clear());
                ConnectToServer(txtClientAddress.Text, int.Parse(txtClientPort.Text));
            } catch (Exception ex)
            {
                 UpdateGameLog($"Error in setting up client: {ex}");
            }
        }

        /// <summary>
        /// Click handler for when the user wants to disconnect from the server.
        /// This will cancel the server data task, clear the game log, and stop connections to the server.
        /// </summary>
        /// <param name="sender">Identifies the particular control that raised the click event</param>
        /// <param name="e">Holds the EventArgs object sent to the routine</param>
        private void btnStopClient_Click(object sender, EventArgs e)
        {
            clientCTS!.Cancel();
            ControlInvokeAction<ListBox>(lstGameLog, lst => lst.Items.Clear());
            StopListeningClient();
        }

        /// <summary>
        /// Custom click handler for when the server wants to make a move on the board.
        /// This will first check if the current user is eligible to move a space depending on three values: 
        /// Whether the current turn is true.
        /// If the current index is within the bounds of their buttons (player 1 gets to click the top 5 buttons and player 2
        /// gets to click the bottom 5 buttons).
        /// If the current button's value isn't 0.
        /// If the user's eligible, then a while loop will increment the next button and decrement the positions that the player's value will move
        /// based on the pressedButton's text value (5 in the button will move 5 buttons and increment each by 1).
        /// If the currentIndex is out of bounds, this means that the new button will be the first button in the array (The button array moves clockwise
        /// around the board, starting at the top left button).
        /// After placing the values, a win will be checked. This is checked by looking at the values of each button on the player's side and seeing if
        /// all the buttons are 0.
        /// If there's a win, then the WonTheGame function will be called, else the DidntWinGame function will be called with the currentIndex
        /// function and determine if the player landed in a bin (resulting in another move).
        /// </summary>
        /// <param name="sender">Identifies the particular control that raised the click event</param>
        /// <param name="e">Holds the EventArgs object sent to the routine</param>
        public void buttonMoveSpace_Click(object? sender, EventArgs e)
        {
            Button pressedButton = (Button)sender!;
            int currentIndex = int.Parse((string)pressedButton.Tag!);
            bool eligibility = playerNumber.Equals('0') ? currentIndex >= 1 && currentIndex <= 5 : currentIndex >= 7 && currentIndex <= 11;
            if (currentTurn && !pressedButton.Text.Equals("0") && eligibility)
            {
                int positions = int.Parse(pressedButton.Text);
                pressedButton.Text = "0";
                while (positions > 0)
                {
                    currentIndex = (currentIndex == 12) ? 0 : currentIndex;
                    int buttonValue = int.Parse(buttons![currentIndex].Text) + 1;
                    buttons[currentIndex++].Text = buttonValue.ToString();
                    positions--;
                }

                bool win = (playerNumber.Equals('0')) ? CheckForWin(0, 5) : CheckForWin(6, 11);
                currentTurn = (win) ? WonTheGame() : DidntWinGame(currentIndex);
            }
        }

        /// <summary>
        /// Function for connecting to the server. This will start the client, start the server data task, 
        /// and make the cancel token.
        /// </summary>
        /// <param name="ipAddress">IP address from txtIPAddress</param>
        /// <param name="port">Port number from txtPort</param>
        public void ConnectToServer(string ipAddress, int port)
        {
            client = new TcpClient();
            client.Connect(ipAddress, port);
            clientNetStream = client.GetStream();
            clientNetWriter = new BinaryWriter(clientNetStream);
            clientNetReader = new BinaryReader(clientNetStream);
            UpdateGameLog($"Successfully connected to server at IP address: {ipAddress} on port: {port}");
            clientNetWriter.Write("Client successfully connected to server.");
            clientCTS = new CancellationTokenSource();
            getServerDataThread = Task.Run(GetDataFromServer, clientCTS.Token);
        }

        /// <summary>
        /// Checks to see if a win occurred. This will look through the lower and upper bound
        /// in the button array and see if all of the button texts are equal to 0.
        /// </summary>
        /// <param name="lowerBound">Lower bound of the array, depending on which player's buttons are checked.</param>
        /// <param name="upperBound">Upper bound of the array, depending on which player's buttons are checked.</param>
        /// <returns>Returns false/true, which is used to change the win value.</returns>
        public bool CheckForWin(int lowerBound, int upperBound)
        {
            bool win = true;
            for (int i = lowerBound; i < upperBound; i++)
            {
                if (!buttons![i].Text.Equals("0"))
                {
                    win = false;
                }
            }
            return win;
        }

        /// <summary>
        /// Function for winning the game. This will send the new board to the cleint and write W, which is a protocol
        /// for showing a win. The winner's number will be sent to the client and the winner label will be updated.
        /// </summary>
        /// <returns>Returns false, which is used to change the current turn.</returns>
        public bool WonTheGame()
        {
            SendBoardToServer();
            clientNetWriter!.Write("From Client: W" + playerNumber);
            ControlInvokeAction<Label>(lblWinner, lbl => lbl.Text = "Player " + (char)(playerNumber + 1) + " Wins!");
            return false;
        }

        /// <summary>
        /// Function for when the player didn't win. This will check to see if the player landed on an end bin, resulting
        /// in another turn. This will send the result back as a boolean for the current turn variable. If the
        /// user doesn't have another turn, then the C protocol will be sent to the client, which changes the turn.
        /// Lastly, the new board will be sent to the client.
        /// </summary>
        /// <param name="currentIndex">Current index where the user stopped.</param>
        /// <returns></returns>
        public bool DidntWinGame(int currentIndex)
        {
            bool keepTurn = (currentIndex == 6 || currentIndex == 12) ? true : false;
            if (!keepTurn)
            {
                clientNetWriter!.Write("From Client: C");
            }
            SendBoardToServer();
            return keepTurn;
        }

        /// <summary>
        /// Function for getting data from the server. This will read
        /// all data from the server and place it into the game log. If the
        /// data doesn't equal "~~END~~" then the data will be deciphered and a turn will happen.
        /// If the loop stops (connection ended, often from an error), then the client will be checked to see if it
        /// needs to shutdown.
        /// </summary>
        public void GetDataFromServer()
        {
            string data = "";
            UpdateGameLog("Data watching thread active.");
            try
            {
                do
                {
                    if (clientNetReader != null)
                    {
                        data = clientNetReader!.ReadString();
                        UpdateGameLog(data);
                        if (!data.Equals("~~END~~"))
                        {
                            DecipherServerData(data);
                        }
                    }
                } while (data != "~~END~~");
            }
            catch (Exception)
            {
                CheckIfClientNeedsToForceShutdown();
            }
            CheckIfClientNeedsToForceShutdown();
        }

        /// <summary>
        /// Function for checking to see if the client still exists and stops the connection.
        /// </summary>
        public void CheckIfClientNeedsToForceShutdown()
        {
            if (client != null)
            {
                UpdateGameLog("Closing connection with server...");
                StopListeningClient();
            }
        }

        /// <summary>
        /// Function for stopping the connection with the client. This will
        /// write to the server to end their program and close the connection. Lastly,
        /// the board will reset and the settings will change back to normal.
        /// </summary>
        public void StopListeningClient()
        {
            UpdateGameLog("Attempting to close the connection... ");
            try
            {
                if (clientNetReader != null)
                {
                    clientNetWriter?.Write("~~END~~");
                }
            }
            catch (Exception Ex)
            {
                UpdateGameLog("Error closing connection... " + Ex);
            }

            try
            {
                CloseClientConnections();
            }
            catch (Exception Ex)
            {
                UpdateGameLog("Error closing connection... " + Ex);
            }
            UpdateGameLog("Closed Connection.");
            ResetBoard();
            ChangeSettings();
        }

        /// <summary>
        /// Function for closing all connections with the client.
        /// </summary>
        public void CloseClientConnections()
        {
            clientNetStream?.Close();
            clientNetWriter?.Close();
            clientNetReader?.Close();
            client?.Close();

            clientNetStream = null;
            clientNetWriter = null;
            clientNetReader = null;
            client = null;
            getServerDataThread = null;
        }

        /// <summary>
        /// Function for setting up the board. Makes all of the playable buttons equal to 5
        /// and the bins equal to 0.
        /// </summary>
        public void SetupBoard()
        {
            foreach (Button button in buttons!)
            {
                ControlInvokeAction<Button>(button, btn => btn.Text = "5");
            }
            ControlInvokeAction<Button>(btnPlayerOne, btn => btn.Text = "0");
            ControlInvokeAction<Button>(btnPlayerTwo, btn => btn.Text = "0");
        }

        /// <summary>
        /// Updates the listbox game log with I/O data.
        /// </summary>
        /// <param name="data">Any data that's sent to the listbox.</param>
        public void UpdateGameLog(string data)
        {
            ControlInvokeAction<ListBox>(lstGameLog, lst => lstGameLog.Items.Add(data));
        }

        /// <summary>
        /// Function for enabling/disabling the settings. This locks the client into
        /// their connection and allows for the stop button to be pressed.
        /// </summary>
        public void ChangeSettings()
        {
            ControlInvokeAction<GroupBox>(grpNetworkEnd, grp => grp.Enabled = !grp.Enabled);
            ControlInvokeAction<Button>(btnStartClient, btn => btn.Enabled = !btn.Enabled);
            ControlInvokeAction<Button>(btnStopClient, btn => btn.Enabled = !btn.Enabled);
            ControlInvokeAction<TextBox>(txtClientAddress, txt => txt.Enabled = !txt.Enabled);
            ControlInvokeAction<TextBox>(txtClientPort, txt => txt.Enabled = !txt.Enabled);
        }

        /// <summary>
        /// Function for sending the new board to the server. This is denoted with the B protocol
        /// and will have all of the button texts sent, seperated by commas.
        /// </summary>
        public void SendBoardToServer()
        {
            string board = "";
            foreach (Button button in buttons!)
            {
                board += button.Text + ",";
            }
            board = board.Remove(board.Length - 1);
            clientNetWriter!.Write("From Client: BU-" + board);
        }

        /// <summary>
        /// Function for deciphering a win. This will read if the protocol is W and 
        /// change the label to the winning player.
        /// </summary>
        /// <param name="data">Data sent from the client. Tells which user won based on 0/1 values.</param>
        public void DecipherWin(string data)
        {
            char winnerNumber = data.ElementAt(14).Equals('0') ? '1' : '2';
            ControlInvokeAction<Label>(lblWinner, lbl => lbl.Text = "Player " + winnerNumber + " Wins!");
        }

        /// <summary>
        /// Function for deciphering a board change. This will read if the protocol is B and 
        /// will change the board based on the values given.
        /// </summary>
        /// <param name="data">Data sent from the server. Holds comma seperated values from the server buttons.</param>
        public void DecipherChangeBoard(string data)
        {
            string parseData = data[16..];
            string[] newBoardData = parseData.Split(",");
            int counter = 0;
            foreach (Button button in buttons!)
            {
                ControlInvokeAction<Button>(button, btn => btn.Text = newBoardData[counter]);
                counter++;
            }
        }

        /// <summary>
        /// Function for deciphering when the server wants the client to setup the board. This will
        /// be a 1 character protocol S and will have the game settings data. Based on the data sent,
        /// the playerNumber/goesFirst values will be entered and the current turn will be determined.
        /// The form title will be made and the board will be setup with the default values.
        /// </summary>
        /// <param name="data">Data sent from the server. Protocol to start the board and the game setting values.</param>
        public void DecipherSetupBoard(string data)
        {
            playerNumber = data.ElementAt(14);
            whoGoesFirst = data.ElementAt(15);
            string playerNumberRepresentation = (int.Parse(playerNumber.ToString()) + 1).ToString();
            string whoGoesFirstRepresentation = (int.Parse(whoGoesFirst.ToString()) + 1).ToString();
            currentTurn = playerNumber.Equals(whoGoesFirst);
            ControlInvokeAction<Form>(this, frm => frm.Text += " - I am player " + playerNumberRepresentation
                                        + " and player " + whoGoesFirstRepresentation + " goes first");
            SetupBoard();
        }

        /// <summary>
        /// Function for determining which protocol is being sent from the server. This will 
        /// use a switch statement to decipher the data and see if a board needs to be setup, the board needs to be updated,
        /// the current turn needs to be updated, or if a win occurred.
        /// </summary>
        /// <param name="data">Data sent from the server. Holds 1 charater protocols that distinguises the data.</param>
        public void DecipherServerData(string data)
        {
            char protocol = data.ElementAt(13);
            switch (protocol)
            {
                case 'S':
                    DecipherSetupBoard(data);
                    break;
                case 'B':
                    DecipherChangeBoard(data);
                    break;
                case 'C':
                    currentTurn = true;
                    break;
                case 'W':
                    DecipherWin(data);
                    break;
            }
        }

        /// <summary>
        /// Function for resetting the board with default 0 values, resetting the label and form text,
        /// and resetting the plaeyrNumber/whoGoesFirst values.
        /// </summary>
        public void ResetBoard()
        {
            foreach (Button button in buttons!)
            {
                ControlInvokeAction<Button>(button, btn => btn.Text = "0");
            }
            ControlInvokeAction<Label>(lblWinner, lbl => lbl.Text = "");
            ControlInvokeAction<Form>(this, frm => frm.Text = "Mancala - Client");
            playerNumber = ' ';
            whoGoesFirst = ' ';
        }

        /// <summary>
        /// Function for moving control changes to the correct thread. This will recursively call itself with
        /// the invoke action if it's on a different thread to allow for the data to move to the correct thread.
        /// </summary>
        /// <typeparam name="ctlType">Control generic type.</typeparam>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="propToSet">Action.</param>
        public static void ControlInvokeAction<ctlType>(ctlType controlName, Action<ctlType> propToSet) where ctlType : Control
        {
            if (controlName.InvokeRequired)
            {
                controlName!.Invoke(new Action<ctlType, Action<ctlType>>(ControlInvokeAction), new object[] { controlName, propToSet });
            }
            else
            {
                propToSet(controlName);
            }
        }
    }
}