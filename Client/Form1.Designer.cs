namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.portBox = new System.Windows.Forms.TextBox();
            this.connectToPortButton = new System.Windows.Forms.Button();
            this.messageToSendBox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.conversationBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(87, 47);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(211, 20);
            this.portBox.TabIndex = 0;
            this.portBox.Text = "Insert port number";
            // 
            // connectToPortButton
            // 
            this.connectToPortButton.Location = new System.Drawing.Point(324, 44);
            this.connectToPortButton.Name = "connectToPortButton";
            this.connectToPortButton.Size = new System.Drawing.Size(75, 23);
            this.connectToPortButton.TabIndex = 1;
            this.connectToPortButton.Text = "Connect";
            this.connectToPortButton.UseVisualStyleBackColor = true;
            this.connectToPortButton.Click += new System.EventHandler(this.connectToPortButton_Click);
            // 
            // messageToSendBox
            // 
            this.messageToSendBox.Location = new System.Drawing.Point(87, 93);
            this.messageToSendBox.Multiline = true;
            this.messageToSendBox.Name = "messageToSendBox";
            this.messageToSendBox.Size = new System.Drawing.Size(214, 81);
            this.messageToSendBox.TabIndex = 2;
            this.messageToSendBox.Text = "Write a message to send";
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(324, 93);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(75, 81);
            this.sendMessageButton.TabIndex = 3;
            this.sendMessageButton.Text = "Send message";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // conversationBox
            // 
            this.conversationBox.Location = new System.Drawing.Point(87, 194);
            this.conversationBox.Multiline = true;
            this.conversationBox.Name = "conversationBox";
            this.conversationBox.Size = new System.Drawing.Size(312, 180);
            this.conversationBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 422);
            this.Controls.Add(this.conversationBox);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.messageToSendBox);
            this.Controls.Add(this.connectToPortButton);
            this.Controls.Add(this.portBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Button connectToPortButton;
        private System.Windows.Forms.TextBox messageToSendBox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox conversationBox;
    }
}

