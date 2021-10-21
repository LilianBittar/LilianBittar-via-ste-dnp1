using System;

namespace Birdwatchers
{
    class DeafBirdWatcher{
        public void React(string BirdAction){
            if(BirdAction != "Bird sings") Console.WriteLine("DeafBirdWatcher" + new string[] {"Ooh", "How nice", "Would you look at that"}
                [new Random().Next(0,2)]);
        }
    }
}