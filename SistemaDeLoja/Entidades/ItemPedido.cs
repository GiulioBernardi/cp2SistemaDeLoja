namespace SistemaDeLoja.Entidades
{
    public class ItemPedido
    {
        public int Quantidade { get; set; }
        public double Valor { get; set; }

        public Produto Produto { get; set; }

        public ItemPedido(int quantidade, double valor)
        {
            this.Quantidade = quantidade;
            this.Valor = valor;
        }
        public ItemPedido(int quantidade, double valor, Produto produto)
        {
            this.Quantidade = quantidade;
            this.Valor = valor;
            this.Produto = produto;
        }


        public double Subtotal()
        {
            return this.Quantidade * this.Valor;
        }
        public override string ToString()
        {
            return $"Item Pedido - Quantidade:{Quantidade} - Valor:{Valor}";
        }
    }
}