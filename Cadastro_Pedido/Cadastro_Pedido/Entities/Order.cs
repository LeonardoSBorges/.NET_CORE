using System;
using System.Globalization;
using Cadastro_Pedido.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace Cadastro_Pedido.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrdemItem> Item { get; set; } = new List<OrdemItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrdemItem item)
        {
            Item.Add(item);
        }
        public void RemoveItem(OrdemItem item)
        {
            Item.Remove(item);
        }
        public double Total()
        {
            double ValueTotal = 0.0;

            foreach (OrdemItem item in Item)
            {
                ValueTotal += item.SubTotal();
            }

            return ValueTotal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\n\nRESUMO DO PEDIDO:");
            sb.AppendLine($"Momento do pedido: {Moment} \nStatus do pedido: {Status}");
            sb.AppendLine($"Cliente: {Client.Name} ({Client.BirthDate}) - {Client.Email}");
            sb.AppendLine("ITENS DO PEDIDO: ");
            foreach(OrdemItem item in Item)
            {
                sb.AppendLine($"{item.Product.Name}, ${item.Product.Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantidade: {item.Quantity}, SubTotal: ${item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            }
            sb.AppendLine($"Valor total: {Total().ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();

        }
    }
}
