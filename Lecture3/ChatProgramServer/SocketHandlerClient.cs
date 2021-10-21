using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ChatProgramServer
{
    class SocketHandlerClient
    {
        public List<NetworkStream> connectedCLients = new List<NetworkStream>(); 

        public void HandleClient(TcpClient Client){
            NetworkStream stream = Client.GetStream();
            connectedCLients.Add(stream);

            byte[] dataFromClient = new byte[1024];
            while (true) {
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                if (s == "exit") break;
                Console.WriteLine(s);

                Broadcast(s);
            }
            connectedCLients.Remove(stream);
            Client.Close();
        }

        public void Broadcast(string message){
            foreach(var client in connectedCLients){
                byte[] dataToClient = Encoding.ASCII.GetBytes($"Returning {message}");
                client.Write(dataToClient, 0, dataToClient.Length);
            }
        }
    }
}