namespace Client
{
    partial class Form1
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
            serverAddressTextBox = new TextBox();
            portTextBox = new TextBox();
            connectButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            selectFileButton = new Button();
            fileNameTextBox = new TextBox();
            sendDataButton = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            disconnectButton = new Button();
            cancelButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // serverAddressTextBox
            // 
            serverAddressTextBox.Location = new Point(68, 52);
            serverAddressTextBox.Name = "serverAddressTextBox";
            serverAddressTextBox.Size = new Size(167, 31);
            serverAddressTextBox.TabIndex = 0;
            serverAddressTextBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(263, 52);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(61, 31);
            portTextBox.TabIndex = 1;
            portTextBox.Text = "12345";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(347, 52);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(112, 34);
            connectButton.TabIndex = 2;
            connectButton.Text = "Connect ";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new Point(15, 25);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(112, 34);
            selectFileButton.TabIndex = 3;
            selectFileButton.Text = "Select File";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Enabled = false;
            fileNameTextBox.Location = new Point(137, 28);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(435, 31);
            fileNameTextBox.TabIndex = 4;
            // 
            // sendDataButton
            // 
            sendDataButton.Location = new Point(166, 97);
            sendDataButton.Name = "sendDataButton";
            sendDataButton.Size = new Size(112, 34);
            sendDataButton.TabIndex = 5;
            sendDataButton.Text = "Send";
            sendDataButton.UseVisualStyleBackColor = true;
            sendDataButton.Click += sendDataButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cancelButton);
            panel1.Controls.Add(fileNameTextBox);
            panel1.Controls.Add(sendDataButton);
            panel1.Controls.Add(selectFileButton);
            panel1.Enabled = false;
            panel1.Location = new Point(29, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(591, 150);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 20);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 7;
            label1.Text = "Server IP Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 20);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 8;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 52);
            label3.Name = "label3";
            label3.Size = new Size(16, 25);
            label3.TabIndex = 9;
            label3.Text = ":";
            // 
            // disconnectButton
            // 
            disconnectButton.Enabled = false;
            disconnectButton.Location = new Point(478, 52);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(112, 34);
            disconnectButton.TabIndex = 10;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(318, 97);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 259);
            Controls.Add(disconnectButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(connectButton);
            Controls.Add(portTextBox);
            Controls.Add(serverAddressTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox serverAddressTextBox;
        private TextBox portTextBox;
        private Button connectButton;
        private OpenFileDialog openFileDialog1;
        private Button selectFileButton;
        private TextBox fileNameTextBox;
        private Button sendDataButton;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button disconnectButton;
        private Button cancelButton;
    }
}
