using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class ProdutoDetalheRepository : GenericRepository<ProdutoDetalhe>
    {
        public ProdutoDetalheRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public ProdutoDetalhe GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new ProdutoDetalhe();

            var Banner = _session.ProdutoDetalhe.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new ProdutoDetalhe();

            return Banner;
        }

        public List<ProdutoDetalhe> GetAll(string status = "", string Id = "")
        {
            if (!string.IsNullOrEmpty(status))
                return _session.ProdutoDetalhe.Where(x => x.Status == int.Parse(status)).ToList();

            if (!string.IsNullOrEmpty(Id))
                return _session.ProdutoDetalhe.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.ProdutoDetalhe.ToList();
        }

        public List<ProdutoDetalhe> GetByproduct(string Id = "")
        {
            if (int.Parse(Id) > 0)
                return _session.ProdutoDetalhe.Where(x => x.Produto.Id == int.Parse(Id)).ToList();

          
            return new List<ProdutoDetalhe>();
        }

    }

}
