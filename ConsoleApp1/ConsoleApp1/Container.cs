
namespace ConsoleApp1
{
    public abstract class Container
    {
        private static int _counter = 1;
        public string SerialNumber { get; }
        public double CargoMass { get; protected set; }
        public double Height { get; }
        public double OwnWeight { get; }
        public double Depth { get; }
        public double MaxLoad { get; }

        protected Container(string type, double maxLoad, double height, double depth, double ownWeight)
        {
            SerialNumber = $"KON-{type}-{_counter++}";
            MaxLoad = maxLoad;
            Height = height;
            Depth = depth;
            OwnWeight = ownWeight;
            CargoMass = 0;
        }

        public virtual void EmptyCargo()
        {
            CargoMass = 0;
        }

        public virtual void LoadCargo(double mass)
        {
            if (CargoMass + mass > MaxLoad)
            {
                throw new OverfillException($"Przekroczono maksymalną ładowność kontenera {SerialNumber}");
            }
            CargoMass += mass;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Kontener {SerialNumber}:");
            Console.WriteLine($"  Wysokość: {Height}cm, Głębokość: {Depth}cm");
            Console.WriteLine($"  Waga własna: {OwnWeight}kg, Masa ładunku: {CargoMass}kg");
            Console.WriteLine($"  Maksymalna ładowność: {MaxLoad}kg");
        }
    }
}