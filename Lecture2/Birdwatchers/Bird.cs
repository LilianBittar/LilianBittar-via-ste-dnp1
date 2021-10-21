using System;

namespace Birdwatchers
{
    class Bird {
        public Action<string> BirdAction;

        public void FireEvent() {
            BirdAction?.Invoke(new string[] {"Bird flaps", "Bird sings", "Bird does matting dance"} [new Random().Next(0, 2)]);
        }
    }
}