using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace SendingObjectClient
{
    class ClientReader
    {
        public bool running = true;
        
        public void Read(NetworkStream stream){
            byte[] dataFromServer = new byte[1024];
            while(running) {
                int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
                string json = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
                Message s = JsonSerializer.Deserialize<Message>(json);
                Console.WriteLine(s.MessageBody);
            }
        }
    }
}