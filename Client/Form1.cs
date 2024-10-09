using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using Client.Interfaces;
using Client.Services;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly IDataSender _sender;
        public Form1()
        {
            InitializeComponent();
            _sender = new DataSender();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileNameTextBox.Text = openFileDialog.FileName;
                    _sender.SetFile(fileNameTextBox.Text);
                }
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            int port;
            if (int.TryParse(portTextBox.Text, out port))
            {
                try
                {
                    _sender.Connect(serverAddressTextBox.Text, port);
                    panel1.Enabled = true;
                    connectButton.Enabled = false;
                    disconnectButton.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("nieprawidlowy port servera", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void sendDataButton_Click(object sender, EventArgs e)
        {
            sendDataButton.Enabled = false;
            Thread sendThread = new Thread(new ThreadStart(async () =>
            {
                _sender.SendFile();

                if (sendDataButton.InvokeRequired)
                {
                    sendDataButton.Invoke(new MethodInvoker(delegate
                    {
                        sendDataButton.Enabled = true;
                    }));
                }
            }));

            sendThread.Start();

        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            disconnectButton.Enabled = false;
            _sender.Disconnect();
            connectButton.Enabled = true;
            panel1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _sender.CancelSendingFile();
        }
    }
}
