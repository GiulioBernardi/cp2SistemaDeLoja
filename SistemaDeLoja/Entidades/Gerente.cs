using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLoja.Entidades
{
    internal class Gerente : Funcionario
    {
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double todosOsPedidos = pedidos.Sum(pr => pr.Valor);
            return Salario + (pedidos.Sum(pr => pr.Valor)*0.05);
        }

        public Gerente(String nome, String matricula, double salario) : base(nome, matricula, salario)
        {

        }
    }
}
