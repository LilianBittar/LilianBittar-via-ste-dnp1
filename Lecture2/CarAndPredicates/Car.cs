namespace CarAndPredicates
{
    class Car
    {
        public string Color;
        public int EngineSize;
        public int FuelEconomy;
        public bool IsManualShift;

        public Car(string Color, int EngineSize, int FuelEconomy, bool IsManualShift)
        {
            this.Color = Color;
            this.EngineSize = EngineSize;
            this.FuelEconomy = FuelEconomy;
            this.IsManualShift = IsManualShift;
        }

        public override string ToString()
        {
            return $"Car:[{Color}, {EngineSize}, {FuelEconomy}, {IsManualShift}]";
        }
    }
}