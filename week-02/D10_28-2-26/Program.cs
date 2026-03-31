// assesment in classroom tb

using System;

namespace DynamicTaxEngine
{
    // 1. Entity Class
    public class TaxPayer
    {
        public int TaxPayerId { get; set; }
        public string Name { get; set; }
        public double Income { get; set; }
        public double Surcharge { get; set; }
    }

    // 3. Core Tax Engine (No Tax Rules Inside)
    public class TaxEngine
    {
        public void Compute(TaxPayer taxPayer, string category, Func<TaxPayer, double> calculator)
        {
            double tax = calculator(taxPayer);

            Console.WriteLine("========= TAX COMPUTATION =========");
            Console.WriteLine($"Name     : {taxPayer.Name}");
            Console.WriteLine($"Category : {category}");
            Console.WriteLine($"Tax      : {tax}");
            Console.WriteLine("---------------------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 5. Hardcoded Dataset
            TaxPayer taxPayer = new TaxPayer
            {
                TaxPayerId = 801,
                Name = "Ravi",
                Income = 800000,
                Surcharge = 20000
            };

            // 2.3 Tax Rule Definitions using Func Delegate

            // Individual Tax → 10%
            Func<TaxPayer, double> individualTaxRule =
                tp => tp.Income * 0.10;

            // Business Tax → 15% + Surcharge
            Func<TaxPayer, double> businessTaxRule =
                tp => (tp.Income * 0.15) + tp.Surcharge;

            // Senior Citizen Tax → 5%
            Func<TaxPayer, double> seniorCitizenTaxRule =
                tp => tp.Income * 0.05;

            // 3. Create Tax Engine
            TaxEngine engine = new TaxEngine();

            // 4. Runtime Configuration
            engine.Compute(taxPayer, "Individual", individualTaxRule);
            engine.Compute(taxPayer, "Business", businessTaxRule);
            engine.Compute(taxPayer, "Senior Citizen", seniorCitizenTaxRule);
        }
    }
}