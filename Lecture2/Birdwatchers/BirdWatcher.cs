using System;

namespace Birdwatchers
{
    class BirdWatcher{
        public void React(string BirdAction){
            Console.WriteLine(new string[] {"Ooh", "How nice", "Would you look at that"} [new Random().Next(0, 2)]);
        }
    }
}