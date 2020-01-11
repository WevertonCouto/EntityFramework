using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class ProdutoDAO : IProdutoDAO, IDisposable
    {
        private LojaContext context;

        public ProdutoDAO()
        {
            context = new LojaContext();
        }


        public void Adicionar(Produto p)
        {
            context.Produtos.Add(p);
            context.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            context.Produtos.Update(p);
            context.SaveChanges();
        }

        public void Remover(Produto produto)
        {
            context.Produtos.Remove(produto);
            context.SaveChanges();
        }

        public List<Produto> Produtos()
        {
            return context.Produtos.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}