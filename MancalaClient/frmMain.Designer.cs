
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
            grpClientSettings = new GroupBox();
            txtClientPort = new TextBox();
            lblClientPort = new Label();
            btnStopClient = new Button();
            btnStartClient = new Button();
            txtClientAddress = new TextBox();
            lblClientAddress = new Label();
            grpNetworkEnd = new GroupBox();
            rdbClientEnd = new RadioButton();
            rdbServerEnd = new RadioButton();
            grpNetworkSettings.SuspendLayout();
            grpClientSettings.SuspendLayout();
            grpNetworkEnd.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlayerOne
            // 
            btnPlayerOne.Location = new Point(12, 12);
            btnPlayerOne.Name = "btnPlayerOne";
            btnPlayerOne.Size = new Size(57, 188);
            btnPlayerOne.TabIndex = 11;
            btnPlayerOne.Tag = "12";
            btnPlayerOne.Text = "0";
            btnPlayerOne.UseVisualStyleBackColor = true;
            // 
            // btnPlayerTwo
            // 
            btnPlayerTwo.Location = new Point(510, 12);
            btnPlayerTwo.Name = "btnPlayerTwo";
            btnPlayerTwo.Size = new Size(57, 188);
            btnPlayerTwo.TabIndex = 5;
            btnPlayerTwo.Tag = "6";
            btnPlayerTwo.Text = "0";
            btnPlayerTwo.UseVisualStyleBackColor = true;
            // 
            // btnOne
            // 
            btnOne.Location = new Point(75, 12);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(81, 51);
            btnOne.TabIndex = 0;
            btnOne.Tag = "1";
            btnOne.Text = "0";
            btnOne.UseVisualStyleBackColor = true;
            // 
            // btnTwo
            // 
            btnTwo.Location = new Point(162, 12);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(81, 51);
            btnTwo.TabIndex = 1;
            btnTwo.Tag = "2";
            btnTwo.Text = "0";
            btnTwo.UseVisualStyleBackColor = true;
            // 
            // btnThree
            // 
            btnThree.Location = new Point(249, 12);
            btnThree.Name = "btnThree";
            btnThree.Size = new Size(81, 51);
            btnThree.TabIndex = 2;
            btnThree.Tag = "3";
            btnThree.Text = "0";
            btnThree.UseVisualStyleBackColor = true;
            // 
            // btnFour
            // 
            btnFour.Location = new Point(336, 12);
            btnFour.Name = "btnFour";
            btnFour.Size = new Size(81, 51);
            btnFour.TabIndex = 3;
            btnFour.Tag = "4";
            btnFour.Text = "0";
            btnFour.UseVisualStyleBackColor = true;
            // 
            // btnFive
            // 
            btnFive.Location = new Point(423, 12);
            btnFive.Name = "btnFive";
            btnFive.Size = new Size(81, 51);
            btnFive.TabIndex = 4;
            btnFive.Tag = "5";
            btnFive.Text = "0";
            btnFive.UseVisualStyleBackColor = true;
            // 
            // btnSix
            // 
            btnSix.Location = new Point(423, 149);
            btnSix.Name = "btnSix";
            btnSix.Size = new Size(81, 51);
            btnSix.TabIndex = 6;
            btnSix.Tag = "7";
            btnSix.Text = "0";
            btnSix.UseVisualStyleBackColor = true;
            // 
            // btnSeven
            // 
            btnSeven.Location = new Point(336, 149);
            btnSeven.Name = "btnSeven";
            btnSeven.Size = new Size(81, 51);
            btnSeven.TabIndex = 7;
            btnSeven.Tag = "8";
            btnSeven.Text = "0";
            btnSeven.UseVisualStyleBackColor = true;
            // 
            // btnEight
            // 
            btnEight.Location = new Point(249, 149);
            btnEight.Name = "btnEight";
            btnEight.Size = new Size(81, 51);
            btnEight.TabIndex = 8;
            btnEight.Tag = "9";
            btnEight.Text = "0";
            btnEight.UseVisualStyleBackColor = true;
            // 
            // btnNine
            // 
            btnNine.Location = new Point(162, 149);
            btnNine.Name = "btnNine";
            btnNine.Size = new Size(81, 51);
            btnNine.TabIndex = 9;
            btnNine.Tag = "10";
            btnNine.Text = "0";
            btnNine.UseVisualStyleBackColor = true;
            // 
            // btnTen
            // 
            btnTen.Location = new Point(75, 149);
            btnTen.Name = "btnTen";
            btnTen.Size = new Size(81, 51);
            btnTen.TabIndex = 10;
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
            lblGameLog.TabIndex = 13;
            lblGameLog.Text = "Game Log:";
            // 
            // lstGameLog
            // 
            lstGameLog.FormattingEnabled = true;
            lstGameLog.ItemHeight = 15;
            lstGameLog.Location = new Point(12, 316);
            lstGameLog.Name = "lstGameLog";
            lstGameLog.Size = new Size(555, 154);
            lstGameLog.TabIndex = 14;
            // 
            // lblWinner
            // 
            lblWinner.AutoSize = true;
            lblWinner.Location = new Point(122, 250);
            lblWinner.Name = "lblWinner";
            lblWinner.Size = new Size(0, 15);
            lblWinner.TabIndex = 12;
            // 
            // grpNetworkSettings
            // 
            grpNetworkSettings.Controls.Add(grpClientSettings);
            grpNetworkSettings.Controls.Add(grpNetworkEnd);
            grpNetworkSettings.Location = new Point(573, 12);
            grpNetworkSettings.Name = "grpNetworkSettings";
            grpNetworkSettings.Size = new Size(271, 280);
            grpNetworkSettings.TabIndex = 0;
            grpNetworkSettings.TabStop = false;
            grpNetworkSettings.Text = "Network Settings:";
            // 
            // grpClientSettings
            // 
            grpClientSettings.Controls.Add(txtClientPort);
            grpClientSettings.Controls.Add(lblClientPort);
            grpClientSettings.Controls.Add(btnStopClient);
            grpClientSettings.Controls.Add(btnStartClient);
            grpClientSettings.Controls.Add(txtClientAddress);
            grpClientSettings.Controls.Add(lblClientAddress);
            grpClientSettings.Location = new Point(6, 108);
            grpClientSettings.Name = "grpClientSettings";
            grpClientSettings.Size = new Size(259, 166);
            grpClientSettings.TabIndex = 1;
            grpClientSettings.TabStop = false;
            // 
            // txtClientPort
            // 
            txtClientPort.Location = new Point(154, 50);
            txtClientPort.Name = "txtClientPort";
            txtClientPort.Size = new Size(99, 23);
            txtClientPort.TabIndex = 3;
            // 
            // lblClientPort
            // 
            lblClientPort.AutoSize = true;
            lblClientPort.Location = new Point(9, 53);
            lblClientPort.Name = "lblClientPort";
            lblClientPort.Size = new Size(67, 15);
            lblClientPort.TabIndex = 2;
            lblClientPort.Text = "Server Port:";
            // 
            // btnStopClient
            // 
            btnStopClient.Enabled = false;
            btnStopClient.Location = new Point(9, 119);
            btnStopClient.Name = "btnStopClient";
            btnStopClient.Size = new Size(244, 37);
            btnStopClient.TabIndex = 5;
            btnStopClient.Text = "Stop Client";
            btnStopClient.UseVisualStyleBackColor = true;
            btnStopClient.Click += btnStopClient_Click;
            // 
            // btnStartClient
            // 
            btnStartClient.Location = new Point(9, 79);
            btnStartClient.Name = "btnStartClient";
            btnStartClient.Size = new Size(244, 34);
            btnStartClient.TabIndex = 4;
            btnStartClient.Text = "Start Client";
            btnStartClient.UseVisualStyleBackColor = true;
            btnStartClient.Click += btnStartClient_Click;
            // 
            // txtClientAddress
            // 
            txtClientAddress.Location = new Point(154, 21);
            txtClientAddress.Name = "txtClientAddress";
            txtClientAddress.Size = new Size(99, 23);
            txtClientAddress.TabIndex = 1;
            // 
            // lblClientAddress
            // 
            lblClientAddress.AutoSize = true;
            lblClientAddress.Location = new Point(9, 24);
            lblClientAddress.Name = "lblClientAddress";
            lblClientAddress.Size = new Size(87, 15);
            lblClientAddress.TabIndex = 0;
            lblClientAddress.Text = "Server Address:";
            // 
            // grpNetworkEnd
            // 
            grpNetworkEnd.Controls.Add(rdbClientEnd);
            grpNetworkEnd.Controls.Add(rdbServerEnd);
            grpNetworkEnd.Location = new Point(6, 22);
            grpNetworkEnd.Name = "grpNetworkEnd";
            grpNetworkEnd.Size = new Size(259, 80);
            grpNetworkEnd.TabIndex = 1;
            grpNetworkEnd.TabStop = false;
            grpNetworkEnd.Text = "Network End:";
            // 
            // rdbClientEnd
            // 
            rdbClientEnd.AutoSize = true;
            rdbClientEnd.Checked = true;
            rdbClientEnd.Enabled = false;
            rdbClientEnd.Location = new Point(154, 34);
            rdbClientEnd.Name = "rdbClientEnd";
            rdbClientEnd.Size = new Size(56, 19);
            rdbClientEnd.TabIndex = 1;
            rdbClientEnd.TabStop = true;
            rdbClientEnd.Text = "Client";
            rdbClientEnd.UseVisualStyleBackColor = true;
            // 
            // rdbServerEnd
            // 
            rdbServerEnd.AutoSize = true;
            rdbServerEnd.Enabled = false;
            rdbServerEnd.Location = new Point(52, 34);
            rdbServerEnd.Name = "rdbServerEnd";
            rdbServerEnd.Size = new Size(57, 19);
            rdbServerEnd.TabIndex = 0;
            rdbServerEnd.Text = "Server";
            rdbServerEnd.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 484);
            Controls.Add(grpNetworkSettings);
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
            Text = "Mancala - Client";
            Load += frmMain_Load;
            grpNetworkSettings.ResumeLayout(false);
            grpClientSettings.ResumeLayout(false);
            grpClientSettings.PerformLayout();
            grpNetworkEnd.ResumeLayout(false);
            grpNetworkEnd.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void rdbServerEnd_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
        private GroupBox grpNetworkEnd;
        private RadioButton rdbClientEnd;
        private RadioButton rdbServerEnd;
        private GroupBox grpClientSettings;
        private TextBox txtClientPort;
        private Label lblClientPort;
        private Button btnStopClient;
        private Button btnStartClient;
        private TextBox txtClientAddress;
        private Label lblClientAddress;
    }
}
