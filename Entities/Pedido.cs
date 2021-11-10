using Atividade.Fixacao.Enums_Composicao.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade.Fixacao.Enums_Composicao.Entities
{
    class Pedido
    {
        public DateTime Momento { get; set; }

        public StatusProduto Status { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido> Items { get; set; } = new List<ItemPedido>();

        public Pedido()
        {

        }

        public Pedido(DateTime momento, StatusProduto status, Cliente cliente)
        {
            Momento = momento;
            Status = status;
            Cliente = cliente;
        }
        public void AddItem(ItemPedido item)
        {
            Items.Add(item);
        }
        public void RemoverItem(ItemPedido item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach (ItemPedido item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Momento Pedido: " + Momento.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Status Pedido: " + Status);
            sb.AppendLine("Cliente: " + Cliente);
            sb.AppendLine("Items Pedido: ");
            foreach (ItemPedido item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
