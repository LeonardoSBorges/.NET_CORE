using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace CalculoContribuinte.Entities
{
    class LegalPerson : Taxpayers
    {
        public double Employees { get; set; }

        public LegalPerson()
        {
        }
        public LegalPerson(string name, double annualIncome, double employees) : base (name, annualIncome)
        {
            Employees = employees;
        }

        public override double Taxes()
        {
            double Tax;
            if (Employees > 10)
                Tax = AnnualIncome * 0.14;
            else
                Tax = AnnualIncome * 0.16;

            return Tax;
        }

        public override string TaxData()
        {
            return base.TaxData() + ": " + Taxes().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
