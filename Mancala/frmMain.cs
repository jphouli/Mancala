using System.Net;
using System.Net.Sockets;

namespace Mancala
{
    /// <summary>
    /// Filename: frmMain.cs
    /// Part of Project: Mancala
    /// 
    /// File Purpose: The server-side portion of the Mancala game.
    /// 
    /// Program Purpose: This program will setup the server
    /// portion of the Mancala game, connect with the client program,
    /// and play out the game of Mancala while sending the game data
    /// to the client.
    /// </summary>
    public partial class frmMain : Form
    {
        //VARIABLES
        TcpListener ?server; // Server
        Socket ?serverConnection; // Server connection
        NetworkStream ?serverNetStream; // Server net stream
        BinaryWriter ?serverNetWriter; // Server writer
        BinaryReader ?serverNetReader; // Server reader
        Task ?serverThread; // Server task so the program doesnt lock up
        Task ?getClientDataThread; // Client data task
        CancellationTokenSource ?dataThreadCTS; // Cancel token for the client data task
        CancellationTokenSource ?serverThreadCTS; // Cancel token for the server task
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
            buttons = [btnOne, btnTwo, btnThree, btnFour, btnFive, btnPlayerTwo, btnSix, btnSeven, btnEight, btnNine, btnTen, btnPlayerOne];
            foreach (Button button in buttons)
            {
                button.Click += buttonMoveSpace_Click;
            }
        }

        /// <summary>
        /// Click handler for when the user wants to start a server.
        /// This will parse out the port and check if it's valid (integer value, didn't check if the port number was within a range).
        /// Change the settings of the buttons/groupboxes to stop the user from changing their settings after setting up the server.
        /// Clearing the listbox that will hold all of the I/O from the client.
        /// Updating the game log to tell the user that the server is starting.
        /// Booting up the server with the localhost IP address and the port number entered into txtPort.
        /// If there's an error setting up the server, then the server will be notified.
        /// </summary>
        /// <param name="sender">Identifies the particular control that raised the click event</param>
        /// <param name="e">Holds the EventArgs object sent to the routine</param>
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            int.TryParse(txtServerPort.Text, out int result);
            if (result == 0)
            {
                lstGameLog.Items.Add("Invalid server port...");
                return;
            }

            ChangeSettings();
            ControlInvokeAction<ListBox>(lstGameLog, lst => lst.Items.Clear());
            UpdateGameLog("Starting server...");
            try
            {
                BootUpServer(IPAddress.Parse("127.0.0.1"), result);
            } catch(Exception ex) 
            {
                UpdateGameLog("Error in setting up server... " + ex);
            }
        }

        /// <summary>
        /// Click handler for when the user wants to stop the server.
        /// This will cancel all tasks, clear the listbox of any values,
        /// and start disconnecting the connections of the server/client.
        /// </summary>
        /// <param name="sender">Identifies the particular control that raised the click event</param>
        /// <param name="e">Holds the EventArgs object sent to the routine</param>
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            serverThreadCTS?.Cancel();
            dataThreadCTS?.Cancel();
            ControlInvokeAction<ListBox>(lstGameLog, lst => lst.Items.Clear());
            StopListeningServer();
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
        /// Function for starting the server. Creates/Starts the server based on the localhost IP address
        /// and the port number, then starts the server task and makes the cancel token.
        /// </summary>
        /// <param name="ipAddress">Localhost IP</param>
        /// <param name="port">Port number from txtPort</param>
        public void BootUpServer(IPAddress ipAddress, int port)
        {
            server = new TcpListener(ipAddress, port);
            server.Start();
            UpdateGameLog("Started server on port: " + txtServerPort.Text);
            serverThreadCTS = new CancellationTokenSource();
            serverThread = Task.Run(ListeningForConnectionTask, serverThreadCTS.Token);
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
            SendBoardToClient();
            serverNetWriter!.Write("From Server: W" + playerNumber);
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
                serverNetWriter!.Write("From Server: C");
            }
            SendBoardToClient();
            return keepTurn;
        }

        /// <summary>
        /// Function for getting data from the client. This will read
        /// all data from the client and place it into the game log. If the
        /// data doesn't equal "~~END~~" then the data will be deciphered and a turn will happen.
        /// If the loop stops (connection ended, often from an error), then the server will be checked to see if it
        /// needs to shutdown.
        /// </summary>
        public void GetDataFromClient()
        {
            string data = "";
            UpdateGameLog("Data watching thread active.");
            try
            {
                do
                {
                    if (serverNetReader != null)
                    {
                        data = serverNetReader.ReadString();
                        UpdateGameLog(data);
                        if (!data.Equals("~~END~~"))
                        {
                            DecipherClientData(data);
                        }
                    }
                } while (data != "~~END~~" && serverConnection!.Connected);
            }
            catch (Exception)
            {
                CheckIfServerNeedsToForceShutdown();
            }
            CheckIfServerNeedsToForceShutdown();
        }
        
        /// <summary>
        /// Function for checking to see if the server still exists and stops the connection.
        /// </summary>
        public void CheckIfServerNeedsToForceShutdown()
        {
            if (server != null)
            {
                UpdateGameLog("Closing connection with client...");
                StopListeningServer();
            }
        }

        /// <summary>
        /// Function for stopping the connection with the server/client. This will
        /// write to the client to end their program and close the connection. Lastly,
        /// the board will reset and the settings will change back to normal.
        /// </summary>
        public void StopListeningServer()
        {
            UpdateGameLog("Attempting to close the connection... ");
            try
            {
                if (serverNetReader != null)
                {
                    serverNetWriter?.Write("~~END~~");
                }
            }
            catch (Exception Ex)
            {
                UpdateGameLog("Error closing connection... " + Ex);
            }

            try
            {
                CloseServerConnections();
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
        /// Function for closing all connections with the server.
        /// </summary>
        public void CloseServerConnections()
        {
            serverNetStream?.Close();
            serverNetWriter?.Close();
            serverNetReader?.Close();
            server?.Stop();
            serverNetStream = null;
            serverNetWriter = null;
            serverNetReader = null;
            server = null;
            serverThread = null;
            getClientDataThread = null;
        }

        /// <summary>
        /// Function that listens for client connections. This
        /// will hook up the server to the client and make a data task for the client
        /// that reads all I/O data. Lastly, the game settings will be sent to the client
        /// and the board will be setup.
        /// </summary>
        public void ListeningForConnectionTask()
        {
            UpdateGameLog("Listening for client connection...");
            Application.DoEvents();
            serverConnection = server!.AcceptSocket();
            serverNetStream = new NetworkStream(serverConnection);
            serverNetWriter = new BinaryWriter(serverNetStream);
            serverNetReader = new BinaryReader(serverNetStream);
            dataThreadCTS = new CancellationTokenSource();
            getClientDataThread = Task.Run(GetDataFromClient, dataThreadCTS.Token);
            SendClientGameSettings();
            SetupBoard();
        }

        /// <summary>
        /// Sends the playerNumber and goesFirst values to the client. This will give
        /// 0/1 values to determine player 1/player 2 and player1goesfirst/player2goesfirst.
        /// The values are based on the radiobuttons clicked by the server and the current turn/form title
        /// will be updated.
        /// </summary>
        public void SendClientGameSettings()
        {
            string clientPlayerNumber;
            string goesFirst;
            string formTitle = "";

            clientPlayerNumber = (rdbPlayer1.Checked) ? "1" : "0";
            playerNumber = (rdbPlayer1.Checked) ? '0' : '1';
            formTitle += " - I am player " + (int.Parse(playerNumber.ToString()) + 1).ToString() + " and ";
            goesFirst = (rdbGoesFirst1.Checked) ? "0" : "1";
            whoGoesFirst = (rdbGoesFirst1.Checked) ? '0' : '1';
            formTitle += "player " + (int.Parse(goesFirst) + 1).ToString() + " goes first";
            currentTurn = (playerNumber.Equals(whoGoesFirst)) ? true : false;
            ControlInvokeAction<Form>(this, frm => frm.Text += formTitle);
            serverNetWriter!.Write("From Server: S" + clientPlayerNumber + goesFirst);
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
        /// Function for enabling/disabling the settings. This locks the server into
        /// their choice and allows for the stop button to be pressed.
        /// </summary>
        public void ChangeSettings()
        {
            ControlInvokeAction<GroupBox>(grpGameControls, grp => grp.Enabled = !grp.Enabled);
            ControlInvokeAction<Button>(btnStartServer, btn => btn.Enabled = !btn.Enabled);
            ControlInvokeAction<Button>(btnStopServer, btn => btn.Enabled = !btn.Enabled);
            ControlInvokeAction<TextBox>(txtServerPort, txt => txt.Enabled = !txt.Enabled);
        }

        /// <summary>
        /// Function for sending the new board to the client. This is denoted with the B protocol
        /// and will have all of the button texts sent, seperated by commas.
        /// </summary>
        public void SendBoardToClient()
        {
            string board = "";
            foreach (Button button in buttons!)
            {
                board += button.Text + ",";
            }
            board = board.Remove(board.Length - 1);
            serverNetWriter!.Write("From Server: BU-" + board);
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
        /// <param name="data">Data sent from the client. Holds comma seperated values from the client buttons.</param>
        public void DecipherBoardChange(string data)
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
        /// Function for determining which protocol is being sent from the client. This will 
        /// use a switch statement to decipher the data and see if the board needs to be updated,
        /// the current turn needs to be updated, or if a win occurred.
        /// </summary>
        /// <param name="data">Data sent from the client. Holds 1 charater protocols that distinguises the data.</param>
        public void DecipherClientData(string data)
        {
            char protocol = data.ElementAt(13);
            switch (protocol) 
            {
                case 'B':
                    DecipherBoardChange(data);
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
            ControlInvokeAction<Form>(this, frm => frm.Text = "Mancala - Server");
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