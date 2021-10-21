using System;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Client..");
            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();
            string input;
            do
            {
                input = Console.ReadLine();
                byte[] dataToServer = Encoding.ASCII.GetBytes(input);
                stream.Write(dataToServer, 0, dataToServer.Length);

                byte[] dataFromServer = new byte[1024];
                int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
                string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
                Console.WriteLine(response);
            } while (input != "exit");
            stream.Close();
            client.Close();
        }
    }
}