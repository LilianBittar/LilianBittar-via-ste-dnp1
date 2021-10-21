using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatProgramServer
{
    class Program {
    
        static void Main(string[] args) {
            Console.WriteLine("Starting Server...");

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 5000);
            listener.Start();

            Console.WriteLine("Server started...");
            var handler = new SocketHandlerClient();
            while (true) {
                Thread thread = new Thread(() => handler.HandleClient(listener.AcceptTcpClient()));
                thread.Start();
            }
        }
    }
}