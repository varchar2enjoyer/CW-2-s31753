using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class RefrigeratedContainer : Container
    {
        private static readonly Dictionary<string, double> ProductTemperatures = new Dictionary<string, double>
        {
            {"Bananas", 13.3},
            {"Chocolate", 18},
            {"Fish", 2},
            {"Meat", -15},
            {"Ice cream", -18},
            {"Frozen pizza", -30},
            {"Cheese", 7.2},
            {"Sausages", 5},
            {"Butter", 20.5},
            {"Eggs", 19}
        };

        public string ProductType { get; }
        public double Temperature { get; }

        public RefrigeratedContainer(double maxLoad, string productType, double temperature, double height, double depth, double ownWeight)
            : base("C", maxLoad, height, depth, ownWeight)
        {
            if (!ProductTemperatures.ContainsKey(productType))
            {
                throw new ArgumentException($"Nieznany typ produktu: {productType}");
            }

            if (temperature < ProductTemperatures[productType])
            {
                throw new ArgumentException($"Temperatura {temperature}°C jest zbyt niska dla {productType} (wymagane minimum: {ProductTemperatures[productType]}°C)");
            }

            ProductType = productType;
            Temperature = temperature;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Typ produktu: {ProductType}, Temperatura: {Temperature}°C");
        }
    }
}