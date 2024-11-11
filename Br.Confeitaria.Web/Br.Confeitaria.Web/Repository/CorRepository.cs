using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class CorRepository : GenericRepository<Cor>
    {
        public CorRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Cor GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Cor();

            var Banner = _session.Cor.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Cor();

            return Banner;
        }


        public List<Cor> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Cor.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Cor.ToList();
        }


    }

}
