using System;
using System.Globalization;
using Cadastro_Pedido.Entities;
using Cadastro_Pedido.Entities.Enums;


namespace Cadastro_Pedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dados Cliente: ");
            Console.Write("Nome: ");
            string clientName = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("insira os dados do pedido: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("Quantos pedidos serão feitos? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Dados do item #"+ i);
                Console.Write("Nome do produto: ");
                string productName = Console.ReadLine();

                Console.Write("Preço do produto: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantidade: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrdemItem item = new OrdemItem(quantity, price, product);
                order.AddItem(item);
            }

            Console.WriteLine(order);
        }
    }
}
