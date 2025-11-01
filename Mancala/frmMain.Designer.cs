namespace Mancala
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPlayerOne = new Button();
            btnPlayerTwo = new Button();
            btnOne = new Button();
            btnTwo = new Button();
            btnThree = new Button();
            btnFour = new Button();
            btnFive = new Button();
            btnSix = new Button();
            btnSeven = new Button();
            btnEight = new Button();
            btnNine = new Button();
            btnTen = new Button();
            lblGameLog = new Label();
            lstGameLog = new ListBox();
            lblWinner = new Label();
            grpNetworkSettings = new GroupBox();
            grpServerSettings = new GroupBox();
            btnStartServer = new Button();
            btnStopServer = new Button();
            txtServerPort = new TextBox();
            lblServerPort = new Label();
            grpNetworkEnd = new GroupBox();
            rdbClientEnd = new RadioButton();
            rdbServerEnd = new RadioButton();
            grpGameControls = new GroupBox();
            lblGameControlsNotice = new Label();
            grpGoesFirst = new GroupBox();
            rdbGoesFirst2 = new RadioButton();
            rdbGoesFirst1 = new RadioButton();
            grpChoosePlayer = new GroupBox();
            rdbPlayer2 = new RadioButton();
            rdbPlayer1 = new RadioButton();
            grpNetworkSettings.SuspendLayout();
            grpServerSettings.SuspendLayout();
            grpNetworkEnd.SuspendLayout();
            grpGameControls.SuspendLayout();
            grpGoesFirst.SuspendLayout();
            grpChoosePlayer.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlayerOne
            // 
            btnPlayerOne.Location = new Point(12, 12);
            btnPlayerOne.Name = "btnPlayerOne";
            btnPlayerOne.Size = new Size(57, 188);
            btnPlayerOne.TabIndex = 13;
            btnPlayerOne.Tag = "12";
            btnPlayerOne.Text = "0";
            btnPlayerOne.UseVisualStyleBackColor = true;
            // 
            // btnPlayerTwo
            // 
            btnPlayerTwo.Location = new Point(510, 12);
            btnPlayerTwo.Name = "btnPlayerTwo";
            btnPlayerTwo.Size = new Size(57, 188);
            btnPlayerTwo.TabIndex = 7;
            btnPlayerTwo.Tag = "6";
            btnPlayerTwo.Text = "0";
            btnPlayerTwo.UseVisualStyleBackColor = true;
            // 
            // btnOne
            // 
            btnOne.Location = new Point(75, 12);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(81, 51);
            btnOne.TabIndex = 2;
            btnOne.Tag = "1";
            btnOne.Text = "0";
            btnOne.UseVisualStyleBackColor = true;
            // 
            // btnTwo
            // 
            btnTwo.Location = new Point(162, 12);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(81, 51);
            btnTwo.TabIndex = 3;
            btnTwo.Tag = "2";
            btnTwo.Text = "0";
            btnTwo.UseVisualStyleBackColor = true;
            // 
            // btnThree
            // 
            btnThree.Location = new Point(249, 12);
            btnThree.Name = "btnThree";
            btnThree.Size = new Size(81, 51);
            btnThree.TabIndex = 4;
            btnThree.Tag = "3";
            btnThree.Text = "0";
            btnThree.UseVisualStyleBackColor = true;
            // 
            // btnFour
            // 
            btnFour.Location = new Point(336, 12);
            btnFour.Name = "btnFour";
            btnFour.Size = new Size(81, 51);
            btnFour.TabIndex = 5;
            btnFour.Tag = "4";
            btnFour.Text = "0";
            btnFour.UseVisualStyleBackColor = true;
            // 
            // btnFive
            // 
            btnFive.Location = new Point(423, 12);
            btnFive.Name = "btnFive";
            btnFive.Size = new Size(81, 51);
            btnFive.TabIndex = 6;
            btnFive.Tag = "5";
            btnFive.Text = "0";
            btnFive.UseVisualStyleBackColor = true;
            // 
            // btnSix
            // 
            btnSix.Location = new Point(423, 149);
            btnSix.Name = "btnSix";
            btnSix.Size = new Size(81, 51);
            btnSix.TabIndex = 8;
            btnSix.Tag = "7";
            btnSix.Text = "0";
            btnSix.UseVisualStyleBackColor = true;
            // 
            // btnSeven
            // 
            btnSeven.Location = new Point(336, 149);
            btnSeven.Name = "btnSeven";
            btnSeven.Size = new Size(81, 51);
            btnSeven.TabIndex = 9;
            btnSeven.Tag = "8";
            btnSeven.Text = "0";
            btnSeven.UseVisualStyleBackColor = true;
            // 
            // btnEight
            // 
            btnEight.Location = new Point(249, 149);
            btnEight.Name = "btnEight";
            btnEight.Size = new Size(81, 51);
            btnEight.TabIndex = 10;
            btnEight.Tag = "9";
            btnEight.Text = "0";
            btnEight.UseVisualStyleBackColor = true;
            // 
            // btnNine
            // 
            btnNine.Location = new Point(162, 149);
            btnNine.Name = "btnNine";
            btnNine.Size = new Size(81, 51);
            btnNine.TabIndex = 11;
            btnNine.Tag = "10";
            btnNine.Text = "0";
            btnNine.UseVisualStyleBackColor = true;
            // 
            // btnTen
            // 
            btnTen.Location = new Point(75, 149);
            btnTen.Name = "btnTen";
            btnTen.Size = new Size(81, 51);
            btnTen.TabIndex = 12;
            btnTen.Tag = "11";
            btnTen.Text = "0";
            btnTen.UseVisualStyleBackColor = true;
            // 
            // lblGameLog
            // 
            lblGameLog.AutoSize = true;
            lblGameLog.Location = new Point(12, 298);
            lblGameLog.Name = "lblGameLog";
            lblGameLog.Size = new Size(64, 15);
            lblGameLog.TabIndex = 15;
            lblGameLog.Text = "Game Log:";
            // 
            // lstGameLog
            // 
            lstGameLog.FormattingEnabled = true;
            lstGameLog.ItemHeight = 15;
            lstGameLog.Location = new Point(12, 316);
            lstGameLog.Name = "lstGameLog";
            lstGameLog.Size = new Size(555, 154);
            lstGameLog.TabIndex = 16;
            // 
            // lblWinner
            // 
            lblWinner.AutoSize = true;
            lblWinner.Location = new Point(122, 250);
            lblWinner.Name = "lblWinner";
            lblWinner.Size = new Size(0, 15);
            lblWinner.TabIndex = 14;
            // 
            // grpNetworkSettings
            // 
            grpNetworkSettings.Controls.Add(grpServerSettings);
            grpNetworkSettings.Controls.Add(grpNetworkEnd);
            grpNetworkSettings.Location = new Point(573, 12);
            grpNetworkSettings.Name = "grpNetworkSettings";
            grpNetworkSettings.Size = new Size(271, 280);
            grpNetworkSettings.TabIndex = 0;
            grpNetworkSettings.TabStop = false;
            grpNetworkSettings.Text = "Network Settings:";
            // 
            // grpServerSettings
            // 
            grpServerSettings.Controls.Add(btnStartServer);
            grpServerSettings.Controls.Add(btnStopServer);
            grpServerSettings.Controls.Add(txtServerPort);
            grpServerSettings.Controls.Add(lblServerPort);
            grpServerSettings.Location = new Point(6, 108);
            grpServerSettings.Name = "grpServerSettings";
            grpServerSettings.Size = new Size(259, 166);
            grpServerSettings.TabIndex = 1;
            grpServerSettings.TabStop = false;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(9, 79);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(244, 34);
            btnStartServer.TabIndex = 2;
            btnStartServer.Text = "Start Server";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // btnStopServer
            // 
            btnStopServer.Enabled = false;
            btnStopServer.Location = new Point(9, 119);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(244, 37);
            btnStopServer.TabIndex = 3;
            btnStopServer.Text = "Stop Server";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // txtServerPort
            // 
            txtServerPort.Location = new Point(154, 21);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(99, 23);
            txtServerPort.TabIndex = 1;
            // 
            // lblServerPort
            // 
            lblServerPort.AutoSize = true;
            lblServerPort.Location = new Point(9, 24);
            lblServerPort.Name = "lblServerPort";
            lblServerPort.Size = new Size(100, 15);
            lblServerPort.TabIndex = 0;
            lblServerPort.Text = "Listening on Port:";
            // 
            // grpNetworkEnd
            // 
            grpNetworkEnd.Controls.Add(rdbClientEnd);
            grpNetworkEnd.Controls.Add(rdbServerEnd);
            grpNetworkEnd.Location = new Point(6, 22);
            grpNetworkEnd.Name = "grpNetworkEnd";
            grpNetworkEnd.Size = new Size(259, 80);
            grpNetworkEnd.TabIndex = 0;
            grpNetworkEnd.TabStop = false;
            grpNetworkEnd.Text = "Network End:";
            // 
            // rdbClientEnd
            // 
            rdbClientEnd.AutoSize = true;
            rdbClientEnd.Enabled = false;
            rdbClientEnd.Location = new Point(154, 34);
            rdbClientEnd.Name = "rdbClientEnd";
            rdbClientEnd.Size = new Size(56, 19);
            rdbClientEnd.TabIndex = 1;
            rdbClientEnd.Text = "Client";
            rdbClientEnd.UseVisualStyleBackColor = true;
            // 
            // rdbServerEnd
            // 
            rdbServerEnd.AutoSize = true;
            rdbServerEnd.Checked = true;
            rdbServerEnd.Enabled = false;
            rdbServerEnd.Location = new Point(52, 34);
            rdbServerEnd.Name = "rdbServerEnd";
            rdbServerEnd.Size = new Size(57, 19);
            rdbServerEnd.TabIndex = 0;
            rdbServerEnd.TabStop = true;
            rdbServerEnd.Text = "Server";
            rdbServerEnd.UseVisualStyleBackColor = true;
            // 
            // grpGameControls
            // 
            grpGameControls.Controls.Add(lblGameControlsNotice);
            grpGameControls.Controls.Add(grpGoesFirst);
            grpGameControls.Controls.Add(grpChoosePlayer);
            grpGameControls.Location = new Point(573, 298);
            grpGameControls.Name = "grpGameControls";
            grpGameControls.Size = new Size(271, 174);
            grpGameControls.TabIndex = 1;
            grpGameControls.TabStop = false;
            grpGameControls.Text = "Game Controls:";
            // 
            // lblGameControlsNotice
            // 
            lblGameControlsNotice.AutoSize = true;
            lblGameControlsNotice.Location = new Point(58, 148);
            lblGameControlsNotice.Name = "lblGameControlsNotice";
            lblGameControlsNotice.Size = new Size(165, 15);
            lblGameControlsNotice.TabIndex = 2;
            lblGameControlsNotice.Text = "Server Controls These Settings";
            // 
            // grpGoesFirst
            // 
            grpGoesFirst.Controls.Add(rdbGoesFirst2);
            grpGoesFirst.Controls.Add(rdbGoesFirst1);
            grpGoesFirst.Location = new Point(6, 82);
            grpGoesFirst.Name = "grpGoesFirst";
            grpGoesFirst.Size = new Size(259, 54);
            grpGoesFirst.TabIndex = 1;
            grpGoesFirst.TabStop = false;
            grpGoesFirst.Text = "Goes First:";
            // 
            // rdbGoesFirst2
            // 
            rdbGoesFirst2.AutoSize = true;
            rdbGoesFirst2.Location = new Point(154, 22);
            rdbGoesFirst2.Name = "rdbGoesFirst2";
            rdbGoesFirst2.Size = new Size(85, 19);
            rdbGoesFirst2.TabIndex = 1;
            rdbGoesFirst2.Text = "2 Goes First";
            rdbGoesFirst2.UseVisualStyleBackColor = true;
            // 
            // rdbGoesFirst1
            // 
            rdbGoesFirst1.AutoSize = true;
            rdbGoesFirst1.Checked = true;
            rdbGoesFirst1.Location = new Point(52, 22);
            rdbGoesFirst1.Name = "rdbGoesFirst1";
            rdbGoesFirst1.Size = new Size(85, 19);
            rdbGoesFirst1.TabIndex = 0;
            rdbGoesFirst1.TabStop = true;
            rdbGoesFirst1.Text = "1 Goes First";
            rdbGoesFirst1.UseVisualStyleBackColor = true;
            // 
            // grpChoosePlayer
            // 
            grpChoosePlayer.Controls.Add(rdbPlayer2);
            grpChoosePlayer.Controls.Add(rdbPlayer1);
            grpChoosePlayer.Location = new Point(6, 22);
            grpChoosePlayer.Name = "grpChoosePlayer";
            grpChoosePlayer.Size = new Size(259, 54);
            grpChoosePlayer.TabIndex = 0;
            grpChoosePlayer.TabStop = false;
            grpChoosePlayer.Text = "Player:";
            // 
            // rdbPlayer2
            // 
            rdbPlayer2.AutoSize = true;
            rdbPlayer2.Location = new Point(154, 22);
            rdbPlayer2.Name = "rdbPlayer2";
            rdbPlayer2.Size = new Size(66, 19);
            rdbPlayer2.TabIndex = 1;
            rdbPlayer2.Text = "Player 2";
            rdbPlayer2.UseVisualStyleBackColor = true;
            // 
            // rdbPlayer1
            // 
            rdbPlayer1.AutoSize = true;
            rdbPlayer1.Checked = true;
            rdbPlayer1.Location = new Point(52, 22);
            rdbPlayer1.Name = "rdbPlayer1";
            rdbPlayer1.Size = new Size(66, 19);
            rdbPlayer1.TabIndex = 0;
            rdbPlayer1.TabStop = true;
            rdbPlayer1.Text = "Player 1";
            rdbPlayer1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 484);
            Controls.Add(grpNetworkSettings);
            Controls.Add(grpGameControls);
            Controls.Add(lblWinner);
            Controls.Add(lstGameLog);
            Controls.Add(lblGameLog);
            Controls.Add(btnSix);
            Controls.Add(btnSeven);
            Controls.Add(btnEight);
            Controls.Add(btnNine);
            Controls.Add(btnTen);
            Controls.Add(btnFive);
            Controls.Add(btnFour);
            Controls.Add(btnThree);
            Controls.Add(btnTwo);
            Controls.Add(btnOne);
            Controls.Add(btnPlayerTwo);
            Controls.Add(btnPlayerOne);
            Name = "frmMain";
            Text = "Mancala - Server";
            Load += frmMain_Load;
            grpNetworkSettings.ResumeLayout(false);
            grpServerSettings.ResumeLayout(false);
            grpServerSettings.PerformLayout();
            grpNetworkEnd.ResumeLayout(false);
            grpNetworkEnd.PerformLayout();
            grpGameControls.ResumeLayout(false);
            grpGameControls.PerformLayout();
            grpGoesFirst.ResumeLayout(false);
            grpGoesFirst.PerformLayout();
            grpChoosePlayer.ResumeLayout(false);
            grpChoosePlayer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlayerOne;
        private Button btnPlayerTwo;
        private Button btnOne;
        private Button btnTwo;
        private Button btnThree;
        private Button btnFour;
        private Button btnFive;
        private Button btnSix;
        private Button btnSeven;
        private Button btnEight;
        private Button btnNine;
        private Button btnTen;
        private Label lblGameLog;
        private ListBox lstGameLog;
        private Label lblWinner;
        private GroupBox grpNetworkSettings;
        private GroupBox grpGameControls;
        private GroupBox grpServerSettings;
        private GroupBox grpNetworkEnd;
        private RadioButton rdbClientEnd;
        private RadioButton rdbServerEnd;
        private Button btnStopServer;
        private TextBox txtServerPort;
        private Label lblServerPort;
        private Button btnStartServer;
        private Label lblGameControlsNotice;
        private GroupBox grpGoesFirst;
        private RadioButton rdbGoesFirst2;
        private RadioButton rdbGoesFirst1;
        private GroupBox grpChoosePlayer;
        private RadioButton rdbPlayer2;
        private RadioButton rdbPlayer1;
    }
}
