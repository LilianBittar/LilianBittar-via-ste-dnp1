using System;
using System.Net.Sockets;
using System.Text;

namespace ChatProgram_Client {
    class ClientReader {
        public bool running = true;

        public void Read(NetworkStream stream) {
            byte[] dataFromServer = new byte[1024];
            while (running) {
                int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
                string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
                Console.WriteLine(response);
            }
        }
    }
}