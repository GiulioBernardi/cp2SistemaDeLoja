using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLoja.Entidades
{
    internal abstract class Funcionario
    {
        public String Nome { get; set; }
        public String Matricula { get; set; }
        public double Salario { get; set; }

        public abstract double CalcularPagamento(List<Pedido> pedidos);

        public Funcionario(string nome, string matricula, double salario)
        {
            Nome = nome;
            Matricula = matricula;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"Funcionario - Nome:{Nome} - Matricula:{Matricula} - Salario:{Salario}";
        }
    }
}
