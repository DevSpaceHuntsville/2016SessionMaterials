using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodCs
{
    public struct Product
    {
        public readonly string Name;
        public readonly string Category;
        public readonly decimal Price;

        public Product(string name, string category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }
    }

    public abstract class TaxCalculator
    {
        public decimal CalculateTax(List<Product> items)
        {
            return CalculateFederalTax(items)
                + CalculateStateTax(items)
                + CalculateLocalTax(items);
        }

        public abstract decimal CalculateFederalTax(List<Product> items);
        public abstract decimal CalculateStateTax(List<Product> items);
        public abstract decimal CalculateLocalTax(List<Product> items);
    }

    public class AgnorTaxCalculator : TaxCalculator
    {
        public override decimal CalculateFederalTax(List<Product> items)
        {
            return 0;
        }
        // ...
        public override decimal CalculateStateTax(List<Product> items)
        {
            const decimal rate = 0.06m;
            var subtotal = 0.0m;
            foreach (var item in items) subtotal += item.Price;
            return subtotal * rate;
        }

        public override decimal CalculateLocalTax(List<Product> items)
        {
            const decimal rate = 0.03m;
            var subtotal = 0.0m;
            foreach (var item in items) subtotal += item.Price;
            return subtotal * rate;
        }
    }

    public class BristolTaxCalculator : TaxCalculator
    {
        public override decimal CalculateFederalTax(List<Product> items)
        {
            const decimal rate = 0.20m;
            var subtotal = 0.0m;
            foreach (var item in items) subtotal += item.Price;
            return subtotal * rate;
        }

        public override decimal CalculateStateTax(List<Product> items)
        {
            return 0;
        }

        public override decimal CalculateLocalTax(List<Product> items)
        {
            const decimal rate = 0.015m;
            var subtotal = 0.0m;
            foreach (var item in items)
            {
                if (item.Category == "Food" || item.Category == "Medical") continue;
                subtotal += item.Price;
            }
            return subtotal * rate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Product>()
            {
                new Product("Fan",               "Appliance",   19.99m),
                new Product("Nexium",            "Medical",     69.99m),
                new Product("Chicken Thighs",    "Food",         7.99m),
                new Product("Corn Flakes",       "Food",         4.99m),
                new Product("Bed Sheets",        "Linen",      129.99m),
                new Product("Adjustable Wrench", "Hardware",     6.99m),
            };

            var subtotal = 0.0m;
            foreach (var item in items) subtotal += item.Price;

            var agnorTax = new AgnorTaxCalculator().CalculateTax(items);
            var bristolTax = new BristolTaxCalculator().CalculateTax(items);

            Console.WriteLine("Tax on ${0} of goods in Agnor: ${1:0.00}", subtotal, agnorTax);
            Console.WriteLine("Tax on ${0} of goods in Bristol: ${1:0.00}", subtotal, bristolTax);
        }
    }
}
