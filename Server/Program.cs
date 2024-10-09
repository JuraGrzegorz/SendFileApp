using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;

IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
int port = 12345;

object lockObject = new object();

TcpListener server = new TcpListener(ipAddress, port);
server.Start();

while (true)
{
    TcpClient client = server.AcceptTcpClient();
    Thread connectedClientsThread = new Thread(() =>
    {
        HandleClient(client, lockObject);
    });

    connectedClientsThread.Start();
}


static void HandleClient(TcpClient client, object lockObject)
{
    
    NetworkStream stream = null;
    try
    {
        stream = client.GetStream();

        byte[] dataBuffer = new byte[1024];
        while (true)
        {
            int bufferSize = stream.Read(dataBuffer, 0, dataBuffer.Length);
            byte[] fileSizeBuffer = dataBuffer.Take(sizeof(long)).ToArray();

            long fileSize = BitConverter.ToInt32(fileSizeBuffer, 0);

            string fileName = Path.GetFileName(Encoding.ASCII.GetString(dataBuffer, sizeof(long), bufferSize - sizeof(long)));

            string uniqueIdentifier;
            string filePath;
            lock (lockObject)
            {
                uniqueIdentifier = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff");
                filePath = Path.Combine(@"C:\Users\Juras\Desktop\2024\DotNet\zad4\Server\", @"Data\", uniqueIdentifier);

                if (!Directory.Exists(filePath))
                {

                    Directory.CreateDirectory(filePath);
                }
            }

            filePath = Path.Combine(filePath, fileName);

            long readFileSize = 0;
            using (FileStream fileStream = File.Create(filePath))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
               
                try
                {
                    stream.ReadTimeout = 1000;
                    while (true)
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        readFileSize += bytesRead;
                        
                        fileStream.Write(buffer, 0, bytesRead);
                       
                    }

                }
                catch (IOException ex)
                {
                    stream.ReadTimeout = Timeout.Infinite;

                }
                
            }
            

            if (readFileSize == fileSize)
            {
                Console.WriteLine("Plik przeslany\n");
                stream.Write(Encoding.UTF8.GetBytes("Success"));
            }
            else
            {
                Console.WriteLine("Plik uszkodzony\n");
                stream.Write(Encoding.UTF8.GetBytes("FileCorupted"));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    client.Close();
    Console.WriteLine("koniec");
}