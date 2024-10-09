using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    internal interface IDataSender
    {
        public bool Connect(string ipAddress, int port);
        public void Disconnect();
        public void SetFile(string filePath);
        public void SendFile();
        public void CancelSendingFile();
    }
}
