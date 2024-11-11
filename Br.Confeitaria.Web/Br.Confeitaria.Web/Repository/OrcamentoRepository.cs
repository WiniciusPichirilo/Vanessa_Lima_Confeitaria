using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class OrcamentoRepository : GenericRepository<Orcamento>
    {
        public OrcamentoRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Orcamento GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Orcamento();

            var Banner = _session.Orcamento.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Orcamento();

            return Banner;
        }

        public List<Orcamento> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Orcamento.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Orcamento.ToList();
        }
    }

}
