using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class TipoRepository : GenericRepository<Tipo>
    {
        public TipoRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Tipo GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Tipo();

            var Banner = _session.Tipo.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Tipo();

            return Banner;
        }


        public List<Tipo> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Tipo.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Tipo.ToList();
        }


    }

}
