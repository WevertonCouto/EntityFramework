using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LojaContext())
            {
                var cliente = context
                    .Clientes
                    .Include(c => c.Endereco)
                    .FirstOrDefault();

                //var produto = context
                //    .Produtos
                //    .Include(p => p.Compras)
                //    .Where(p => p.Id == 9004)
                //    .FirstOrDefault();
                var produto = context
                    .Produtos
                    .Where(p => p.Id == 9004)
                    .FirstOrDefault();

                context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(e => e.Preco > 10)
                    .Load();

                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }

            }
        }

        private static void ExibeProdutosDaPromocao()
        {
            using (var context = new LojaContext())
            {
                var promocao = context.Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void AdicionaItensEPromocao()
        {
            using (var context = new LojaContext())
            {
                var promocao = new Promocao();
                promocao.Descricao = "Queima Total de Janeiro";
                promocao.DataInicio = DateTime.Now;
                promocao.DataFim = DateTime.Now.AddMonths(3);

                var produtos = context
                    .Produtos
                    .Where(p => p.Categoria == "Bebida")
                    .ToList();

                foreach (var p in produtos)
                {
                    promocao.IncluiProduto(p);
                }

                contexto.Promocoes.Add(promocao);
                contexto.SaveChanges();
            }
        }
    }
}
