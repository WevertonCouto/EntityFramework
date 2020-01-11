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
            Cliente cliente = new Cliente();
            cliente.Nome = "Fulano";
            cliente.Endereco = new Endereco
            {
                Numero = 12,
                Logradouro = "Rua..."
            };
        }

        private static void MuitosParaMuitos()
        {
            var p1 = new Produto();
            var p2 = new Produto();
            var p3 = new Produto();


            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataFim = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);
            //promocaoDePascoa.Produtos.Add(new Produto());
            //promocaoDePascoa.Produtos.Add(new Produto());


            using (var context = new LojaContext())
            {
                context.Promocoes.Add(promocaoDePascoa);
                context.SaveChanges();

            }
        }
    }
}
