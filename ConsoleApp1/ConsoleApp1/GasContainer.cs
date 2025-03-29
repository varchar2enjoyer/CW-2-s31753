namespace ConsoleApp1
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; }

        public GasContainer(double maxLoad, double pressure, double height, double depth, double ownWeight)
            : base("G", maxLoad, height, depth, ownWeight)
        {
            Pressure = pressure;
        }

        public override void EmptyCargo()
        {
            CargoMass *= 0.05;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[OSTRZEŻENIE] Kontener {SerialNumber}: {message}");
        }
    }
}