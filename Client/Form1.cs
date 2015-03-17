using CommonInstances;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public ClientSide clientSide = new ClientSide();

        public Form1()
        {
            InitializeComponent();
        }

        private void connectToPortButton_Click(object sender, EventArgs e)
        {
            ClientSide.ClientUserInterface = this;
            string portToConnect = portBox.Text;
            clientSide.RegisterClient(portToConnect);
            clientSide.ConnectToServer(portToConnect);
            List<string> oldMessages = clientSide.GetOldMessages();
            foreach (string oldMessage in oldMessages)
            {
                AddNewMessageToConversation(oldMessage);
            }
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            clientSide.sendMessageToServer(messageToSendBox.Text);
        }

        public void AddNewMessageToConversation(string message)
        {
            conversationBox.Text += message + "\r\n";
        }

    }


}
