using System;
using System.Threading;

namespace DoctorsWaitingRoom
{
    public class WaitingRoom
    {
        public Action<int> NumberChange;
        private int currentNumber = 0;
        private int ticketCount = 0;

        public void RunWaitingRoom(){
            while (currentNumber < ticketCount){
                NumberChange?.Invoke(currentNumber);
                currentNumber ++;
                Thread.Sleep(1000);
            }
        }
        
        public int DrawNumber(){
            return ticketCount++;
        }
    }
}