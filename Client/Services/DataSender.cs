using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Interfaces;

namespace Client.Services
{
    internal class DataSender : IDataSender
    {
        private TcpClient? _tcpClient;
        private string? _filePath;
        private NetworkStream? stream;
        private static SemaphoreSlim semaphore;
        public bool Connect(string ipAddress,int port)
        {
            
            _tcpClient = new TcpClient(ipAddress, port);
            semaphore = new SemaphoreSlim(0, 1);
            return true;
        }

        public void Disconnect()
        {
            if(stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (_tcpClient != null)
            {
                _tcpClient.Close();
                _tcpClient = null;
            }
        }


        public void SetFile(string filePath)
        {
            _filePath = filePath;
        }

        public void SendFile()
        {
           if(_filePath == null || _tcpClient==null)
                return;

            if(stream == null)
            {
                stream = _tcpClient.GetStream();
            }

            FileInfo fileInfo = new FileInfo(_filePath);
            byte[] fileSizeBytes = BitConverter.GetBytes(fileInfo.Length);

            byte[] fileNameBytes = Encoding.ASCII.GetBytes(Path.GetFileName(_filePath));
       
            byte[] combinedBytes = fileSizeBytes.Concat(fileNameBytes).ToArray();
            stream.Write(combinedBytes, 0, combinedBytes.Length);

            byte[] buffer = new byte[1024];
            int bytesRead;

            using (FileStream fileStream = File.OpenRead(_filePath))
            {
                
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (semaphore.CurrentCount > 0)
                    {
                        break;
                    }
                    stream.Write(buffer, 0, bytesRead);
                    Thread.Sleep(5);
                }
            }
            
            bytesRead=stream.Read(buffer,0,buffer.Length);
            string receivedMessage =Encoding.UTF8.GetString(buffer, 0, bytesRead);
            MessageBox.Show(receivedMessage, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void CancelSendingFile()
        {
            semaphore.Release();
        }
    }
}
