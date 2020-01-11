using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataFim { get; internal set; }
        public List<PromocaoProduto> Produtos { get; set; }

        public Promocao()
        {
            Produtos = new List<PromocaoProduto>();
        }

        internal void IncluiProduto(Produto p)
        {
            this.Produtos.Add(new PromocaoProduto()
            {
                Produto = p
            });
        }
    }
}
