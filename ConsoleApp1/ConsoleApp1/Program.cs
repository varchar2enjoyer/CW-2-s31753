namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ship ship = new Ship("Neptune", 20, 10, 500);
                
                LiquidContainer liquid = new LiquidContainer(10000, true, 250, 300, 2000);
                GasContainer gas = new GasContainer(8000, 2.5, 200, 250, 1500);
                RefrigeratedContainer fridge = new RefrigeratedContainer(7000, "Bananas", 13.3, 220, 270, 1800);
                
                ship.LoadContainer(liquid);
                ship.LoadContainer(gas);
                ship.LoadContainer(fridge);
                
                liquid.LoadCargo(4000);
                gas.LoadCargo(6000);
                fridge.LoadCargo(5000);
                
                ship.PrintInfo();
                
                liquid.EmptyCargo();
                gas.EmptyCargo();
                fridge.EmptyCargo();

                Console.WriteLine("\nPo rozładowaniu:");
                ship.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }
    }
}