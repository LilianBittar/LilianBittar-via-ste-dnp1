using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ChatProgram_Client;

namespace ChatProgramClient
{
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Starting Client..");
            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();
            var reader = new ClientReader();
            Thread thread = new Thread(() => reader.Read(stream));
            thread.Start();
            string input;
            do {
                input = Console.ReadLine();
                byte[] dataToServer = Encoding.ASCII.GetBytes(input);
                stream.Write(dataToServer, 0, dataToServer.Length);
            } while (input != "exit");

            stream.Close();
            client.Close();
        }
    }
}