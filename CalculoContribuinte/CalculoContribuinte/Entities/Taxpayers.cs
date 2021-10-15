using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoContribuinte.Entities
{
    abstract class Taxpayers
    {
        public string Name { get; set; }
        public double AnnualIncome { get; set; }

        public Taxpayers()
        {
        }

        public Taxpayers(string name, double annualIncome)
        {
            Name = name;
            AnnualIncome = annualIncome;
        }

        public abstract double Taxes();

        public virtual string TaxData()
        {
            return Name;
        }
    }
}
