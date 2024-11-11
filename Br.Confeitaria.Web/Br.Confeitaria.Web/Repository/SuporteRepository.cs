using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class SuporteRepository : GenericRepository<Suporte>
    {
        public SuporteRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Suporte GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Suporte();

            var Banner = _session.Suporte.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Suporte();

            return Banner;
        }

        public List<Suporte> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Suporte.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Suporte.ToList();
        }
    }

}
