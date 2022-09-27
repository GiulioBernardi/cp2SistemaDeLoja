using SistemaDeLoja.Entidades;
using SistemaDeLoja.Enum;

namespace SistemaDeLoja

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boolean saiu = false;
            List<Produto> produtos = new List<Produto>();
            List<Vendedor> vendedores = new List<Vendedor>();
            List<Gerente> gerentes = new List<Gerente>();
            List<Funcionario> funcionarios = new List<Funcionario>();
            List<ItemPedido> itensPedido = new List<ItemPedido>();
            List<Pedido> pedidos = new List<Pedido>();
            while (!saiu)
            {
                

                Console.WriteLine("Bem-vindo ao sistema da loja");
                Console.WriteLine("Digite uma opção:\n" +
                    "1 - Cadastrar Produto\n" +
                    "2 - Cadastrar Funcionário\n" +
                    "3 - Efetuar Venda\n" +
                    "4 - Listar Produtos\n" +
                    "5 - Listar Funcionários\n" +
                    "6 - Listar Pedidos\n" +
                    "7 - Calcular Pagamento de Funcionário\n" +
                    "8 - Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o ID do produto");
                        int idProduto = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o nome do produto");
                        String nomeProduto = Console.ReadLine();

                        Console.WriteLine("Digite o valor do produto");
                        double valorProduto = double.Parse(Console.ReadLine());

                        Produto produto = new Produto(idProduto, nomeProduto, valorProduto);
                        produtos.Add(produto);
                        Console.WriteLine(produtos.First());
                        break;
                    case 2:


                        Console.WriteLine("Digite V para cadastrar vendedor\n" +
                            "Digite G para cadastrar Gerente");
                        String tipoDeFunc = Console.ReadLine().ToLower();

                        Console.WriteLine("Digite o nome do funcionário");
                        String nome = Console.ReadLine();

                        Console.WriteLine("Digite a matricula do funcionário");
                        String matricula = Console.ReadLine();

                        Console.WriteLine("Digite o salário do funcionário");
                        double salario = double.Parse(Console.ReadLine());

                        if (tipoDeFunc == "v")
                        {
                            Vendedor vendedor = new Vendedor(nome, matricula, salario);
                            funcionarios.Add(vendedor);
                        }
                        if (tipoDeFunc == "g")
                        {
                            Gerente gerente = new Gerente(nome, matricula, salario);
                            funcionarios.Add(gerente);
                        }
                        else
                        {
                            Console.WriteLine("Digite G ou V");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Quanto itens irão compor a venda?");
                        int qtdItensVenda = int.Parse(Console.ReadLine());
                        double totalDoItemPedido = 0;

                        Console.WriteLine("Digite a matrícula do funcionário que realizou a venda: ");
                        string matri = Console.ReadLine();

                        Funcionario fun = funcionarios.Find(x => x.Matricula == matri);
                        Pedido pedido = new Pedido();

                        for (int i=0; i<qtdItensVenda; i++)
                        {

                            Console.WriteLine("Id do produto: ");
                            int idProd = int.Parse(Console.ReadLine());
                           
                            Console.WriteLine("Quantidade do produto: ");
                            int qtdProduto = int.Parse(Console.ReadLine());

                            Produto pro = produtos.Find(x => x.Id == idProd);

                            ItemPedido itemPedido = new ItemPedido(qtdProduto, pro.Valor, pro );

                            itensPedido.Add(itemPedido);
                            totalDoItemPedido += itemPedido.Subtotal();


                            pedido.AdicionarItem(itemPedido);

                        }
                        
                        pedidos.Add(pedido);
                        pedido.Status = StatusPedido.Processando;
                        pedido.DataPedido = DateTime.Now;
                        pedido.Valor = totalDoItemPedido;
                        pedido.Funcionario = fun;
                        pedido.ItensPedido = itensPedido;
                        break;
                    case 4:
                        foreach (var p in produtos)
                        {
                            Console.WriteLine(p);
                        }
                        break;
                    case 5:

                        funcionarios.AddRange(gerentes);
                        funcionarios.AddRange(vendedores);
                      
                        foreach (var funcio in funcionarios)
                        {
                            Console.WriteLine(funcio);
                        }
                        break;
                    case 6:
                        foreach (var ped in pedidos)
                        {
                            Console.WriteLine(ped);
                        }
                        break;
                    case 7:

                        Console.WriteLine("Digite a matrícula do funcionário: ");
                        string matric = Console.ReadLine();

                        var f = funcionarios.Find(x => x.Matricula == matric);
                        double sal = f.CalcularPagamento(pedidos);
                        Console.WriteLine("Calculo do pagamento: " + sal);
                       

                        Funcionario func = funcionarios.Find(x => x.Matricula == matric);
                        break;
                    case 8:
                        saiu = true;
                        break;
                }

            }

        }
    }
}