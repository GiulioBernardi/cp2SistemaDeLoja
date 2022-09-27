using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLoja.Entidades
{
    internal class Vendedor : Funcionario
    {
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            List<Pedido> pedidosDesseVendedor = pedidos.Where(x => x.Funcionario.Matricula == Matricula).ToList();
            double comissao = 0;
            foreach(Pedido pedido in pedidosDesseVendedor)
            {
                comissao += pedido.Valor * 0.1;
            }
            return Salario + comissao;
        }

        public Vendedor(String nome, String matricula, double salario) : base(nome, matricula, salario)
        {
          
        }
        
    }
}
