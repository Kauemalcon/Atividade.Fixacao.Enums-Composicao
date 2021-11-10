using Atividade.Fixacao.Enums_Composicao.Entities;
using Atividade.Fixacao.Enums_Composicao.Entities.Enum;
using System;
using System.Globalization;

namespace Atividade.Fixacao.Enums_Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do cliente: ");
            Console.Write("Nome: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data de Nascimento (DD/MM/YYYY): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Entre com os dados do produto: ");
            Console.Write("Status: ");
            StatusProduto status = Enum.Parse<StatusProduto>(Console.ReadLine());

            Cliente cliente = new Cliente(nomeCliente, email, dataNascimento);
            Pedido pedido = new Pedido(DateTime.Now, status, cliente);

            Console.Write("Quantos items para esse pedido? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados pedido #{i} :");
                Console.Write("Nome produto: ");
                string nomeProduto = Console.ReadLine();
                Console.Write("Preço produto: ");
                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Produto produto = new Produto(nomeProduto, preco);

                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());

                ItemPedido itemPedido = new ItemPedido(quantidade, preco, produto);

               pedido.AddItem(itemPedido);
            }

            Console.WriteLine();
            Console.WriteLine("Sumario do pedido:");
            Console.WriteLine(pedido);
        }
    }
    
}
