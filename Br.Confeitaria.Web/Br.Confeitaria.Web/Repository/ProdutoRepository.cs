using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class ProdutoRepository : GenericRepository<Produto>
    {
        public ProdutoRepository(ClassDBContext contexto) : base(contexto)
        {
        }

        public Produto GetId(string Id)
        {

            if (string.IsNullOrEmpty(Id))
                return new Produto();

            var Produto = _session.Produto
             .Include(x => x.Tipo)
             .Include(x => x.Photo)
             .Include(x => x.ProdutoDetalhes)
             .ThenInclude(x => x.Cor)
             .Include(x => x.ProdutoDetalhes)
             .ThenInclude(x => x.Tamanho).Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Produto == null)
                Produto = new Produto();

            return Produto;
        }

        public List<Produto> GetAll(string status = "", string Id = "", string Categoria = "", double VMin= 0, double VMax =0, string Name = "")
        {

            var Produtos = _session.Produto
              .Include(x => x.Tipo)
              .Include(x => x.Photo)
              .Include(x => x.ProdutoDetalhes)
              .ThenInclude(x => x.Cor)
              .Include(x => x.ProdutoDetalhes)
              .ThenInclude(x => x.Tamanho).ToList();

            if (!string.IsNullOrEmpty(Name))
                Produtos = Produtos.Where(x => x.Nome.Contains(Name)).ToList();

            if (!string.IsNullOrEmpty(status))
                Produtos = Produtos.Where(x => x.Status == int.Parse(status)).ToList();

            if (!string.IsNullOrEmpty(Categoria))
                Produtos = Produtos.Where(x => x.Tipo.Id == int.Parse(Categoria)).ToList();

            if (!string.IsNullOrEmpty(Id))
                Produtos = Produtos.Where(x => x.Id == int.Parse(Id)).ToList();

            if ( (VMin) > 0 || (VMax) > 0 )
                Produtos = Produtos.Where( w =>w.ValorVenda >= VMin && w.ValorVenda <= VMax ).ToList();

            return Produtos;
        }

    }

}
