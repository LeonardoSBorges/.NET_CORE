using System;
using System.Globalization;
using CalculoContribuinte.Entities;
using System.Collections.Generic;

namespace CalculoContribuinte
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Taxpayers> list = new List<Taxpayers>();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nTax payer #{i} data: ");
                Console.Write("Individual or company(i/c)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Anual Income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpense = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new PhysicalPerson(name, annualIncome, healthExpense));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int employees = int.Parse(Console.ReadLine());
                    list.Add(new LegalPerson(name, annualIncome, employees));
                }

            }


            Console.WriteLine();
            double total = 0.0;
            foreach (Taxpayers tax in list)
            {
                Console.WriteLine(tax.TaxData());
                total += tax.Taxes();

            }

            Console.WriteLine("\nTOTAL TAXES: "+ total.ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
