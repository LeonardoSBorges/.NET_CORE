using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace CalculoContribuinte.Entities
{
    class PhysicalPerson : Taxpayers
    {
        public double HealthExpense { get; set; }

        public PhysicalPerson()
        {

        }

        public PhysicalPerson(string name, double annualIncome, double healthExpense) : base(name, annualIncome)
        {
            HealthExpense = healthExpense;
        }

        public override double Taxes()
        {
            double Tax;
            if(AnnualIncome > 20000)
            {
                Tax = AnnualIncome * 0.25;
                if (HealthExpense > 0)
                    Tax -= HealthExpense * 0.50; 
            }
            else
                Tax = AnnualIncome * 0.15;

            return Tax;
        }

        public override string TaxData()
        {
            return base.TaxData() +": "+ Taxes().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
