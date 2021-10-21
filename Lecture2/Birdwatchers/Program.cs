using System;

namespace Birdwatchers
{
    class Program
    {
        static void Main(string[] args)
        {
            var Bird = new Bird();
            var BirdWatcher = new BirdWatcher();
            var DeafBirdWatcher = new DeafBirdWatcher();
            var BlindBirdWatcher = new BlindBirdWatcher();

            Bird.BirdAction += BirdWatcher.React;
            Bird.BirdAction += DeafBirdWatcher.React;
            Bird.BirdAction += BlindBirdWatcher.React;

            Bird.FireEvent();
        }
    }
}