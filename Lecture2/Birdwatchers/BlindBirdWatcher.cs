using System;

namespace Birdwatchers
{
    class BlindBirdWatcher{
        public void React(string BirdAction){
            if(BirdAction == "Bird sings") Console.WriteLine("BlindBirdWatcher" + new string[] {"Ooh", "How nice"}
                [new Random().Next(0,1)]);
        }
    }
}