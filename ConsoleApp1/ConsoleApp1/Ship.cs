
namespace ConsoleApp1
{
    public class Ship
    {
        public string Name { get; }
        public double MaxSpeed { get; }
        public int MaxContainers { get; }
        public double MaxWeight { get; }
        private List<Container> Containers { get; }

        public Ship(string name, double maxSpeed, int maxContainers, double maxWeight)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight * 1000;
            Containers = new List<Container>();
        }

        public void LoadContainer(Container container)
        {
            if (Containers.Count >= MaxContainers)
            {
                throw new Exception($"Statek {Name} osiągnął maksymalną liczbę kontenerów: {MaxContainers}");
            }

            double totalWeight = Containers.Sum(c => c.OwnWeight + c.CargoMass) + container.OwnWeight + container.CargoMass;
            if (totalWeight > MaxWeight)
            {
                throw new Exception($"Statek {Name} przekroczyłby maksymalną wagę ładunku: {MaxWeight/1000}t");
            }

            Containers.Add(container);
        }
        
        public void LoadContainers(IEnumerable<Container> containers)
        {
            foreach (var c in containers) LoadContainer(c);
        }

        public void UnloadContainer(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Containers.Remove(container);
            }
        }

        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            var index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
            if (index != -1)
            {
                Containers[index] = newContainer;
            }
        }
        
        public static void TransferContainer(Ship source, Ship target, string serialNumber)
        {
            try
            {
                var container = source.Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
                if (container == null)
                {
                    throw new Exception($"Kontener {serialNumber} nie istnieje na statku źródłowym");
                }

                source.UnloadContainer(serialNumber);
                target.LoadContainer(container);
                Console.WriteLine($"Przeniesiono kontener {serialNumber} pomiędzy statkami");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas transferu kontenera: {ex.Message}");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Statek {Name}:");
            Console.WriteLine($"  Prędkość maks.: {MaxSpeed} węzłów");
            Console.WriteLine($"  Maks. liczba kontenerów: {MaxContainers}, obecnie: {Containers.Count}");
            Console.WriteLine($"  Maks. waga ładunku: {MaxWeight/1000}t, obecnie: {Containers.Sum(c => c.OwnWeight + c.CargoMass)/1000}t");
            Console.WriteLine("Kontenery na statku:");
            foreach (var container in Containers)
            {
                container.PrintInfo();
            }
        }
    }
}