using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeLoja.Enum;
namespace SistemaDeLoja.Entidades
{
    internal class Pedido
    {
        public DateTime DataPedido { get; set; }
        public double Valor { get; set; }
        public StatusPedido Status { get; set; }

        public List<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();

        public Funcionario Funcionario { get; set; }
 
        public Pedido (DateTime dataPedido, double valor, StatusPedido status, Funcionario funcionario)
        {
            this.DataPedido = dataPedido;
            this.Valor = valor;
            this.Status = status;
            this.Funcionario = funcionario;
        }

        public Pedido() { }

        public void AdicionarItem(ItemPedido itemPedido)
        {
            
            ItensPedido.Add(itemPedido);
            Console.WriteLine(ItensPedido.Count);
        }

        public override string ToString()
        {
            return $"Pedido - Data:{DataPedido} - Valor:{Valor} - Status:{Status}";
        }

    }
}
