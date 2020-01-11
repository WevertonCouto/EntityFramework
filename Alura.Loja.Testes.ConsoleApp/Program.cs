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
            //GravarUsandoEntity();
            //RecuperarUsandoEntity();
            //DeletarUsandoEntity(1);
            //DeletarTodosUsandoEntity();
            AtualizarUsandoEntity(new Produto());
        }

        private static void AtualizarUsandoEntity(Produto produto)
        {
            using (var context = new ProdutoDAO())
            {
                context.Atualizar(produto);
            }
        }

        private static void DeletarTodosUsandoEntity()
        {
            List<Produto> list = RecuperarUsandoEntity();
            using (var context = new ProdutoDAO())
            {
                foreach (var item in list)
                {
                    context.Remover(item);
                }
            }
        }

        private static void DeletarUsandoEntity(Produto p)
        {
            using (var context = new ProdutoDAO())
            {
                context.Remover(p);
            }
        }

        private static List<Produto> RecuperarUsandoEntity()
        {
            var list = new List<Produto>();
            using (var context = new ProdutoDAO())
            {
                list = context.Produtos();
            }
            return list;
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var context = new ProdutoDAO())
            {
                context.Adicionar(p);
            }
        }
    }
}
