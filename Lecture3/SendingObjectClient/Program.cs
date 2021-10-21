using System;

namespace SendingObjectClient
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
                Message m = new Message(){
                    TimeStamp = "Dino",
                    MessageBody = input
                };
                byte[] dataToServer = Encoding.ASCII.GetBytes(m.AsJson());
                stream.Write(dataToServer, 0, dataToServer.Length);
            } while (input != "exit");

            stream.Close();
            client.Close();
        }
    }
}