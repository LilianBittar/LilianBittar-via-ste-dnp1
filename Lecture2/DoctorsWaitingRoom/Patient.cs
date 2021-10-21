namespace DoctorsWaitingRoom
{
    public class Patient
    {
        class Patient{
            private int numberInQueue;
            private WaitingRoom waitingRoom;

            public Patient(WaitingRoom wr){
                this.numberInQueue = wr.DrawNumber();
                this.waitingRoom = wr;
                waitingRoom.NumberChange += this.ReactToNumber;
            }

            public void ReactToNumber(int ticketNumber){
                Console.WriteLine("Patien " + numberInQueue + "look up");
                if(numberInQueue == ticketNumber){
                    Console.WriteLine("Patient " + ticketNumber + "has enter the doctor's room");
                    waitingRoom.NumberChange -= this.ReactToNumber;
                }

            }
        }
    }
}