using System;
using System.Globalization;

namespace Produtos.Entities
{
    class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct() { }
        public ImportedProduct(string name, double price, double custumsFee) : base(name, price)
        {
            CustomsFee = custumsFee;
        }

        public override string PriceTag()
        {
            return $"{Name} $ {TotalPrice().ToString("F2", CultureInfo.InvariantCulture)} (Customs fee: $ {CustomsFee.ToString("F2", CultureInfo.InvariantCulture)})";
        }
        public double TotalPrice()
        {
            return Price + CustomsFee;
        }
    }
}
