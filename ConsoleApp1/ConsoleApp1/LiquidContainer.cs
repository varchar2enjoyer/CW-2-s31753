namespace ConsoleApp1
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; }

        public LiquidContainer(double maxLoad, bool isHazardous, double height, double depth, double ownWeight)
            : base("L", maxLoad, height, depth, ownWeight)
        {
            IsHazardous = isHazardous;
        }

        public override void LoadCargo(double mass)
        {
            double allowedLoad = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
            if (mass > allowedLoad)
            {
                NotifyHazard($"Próba przekroczenia dopuszczalnej ładowności dla kontenera z {(IsHazardous ? "niebezpiecznym" : "zwykłym")} płynem");
                throw new OverfillException($"Przekroczono dopuszczalną ładowność dla kontenera {SerialNumber}");
            }
            base.LoadCargo(mass);
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[OSTRZEŻENIE] Kontener {SerialNumber}: {message}");
        }
    }
}