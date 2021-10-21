using System;

namespace DoctorsWaitingRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            var wr = new WaitingRoom();
            var P1 = new Patient(wr);
            var p2 = new Patient(wr);
            var p3 = new Patient(wr);

            wr.RunWaitingRoom();
        }
    }
}