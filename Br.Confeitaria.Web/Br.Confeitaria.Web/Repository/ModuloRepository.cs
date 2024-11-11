using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class ModuloRepository : GenericRepository<Modulo>
    {
        public ModuloRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Modulo GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Modulo();

            var Banner = _session.Modulo.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Modulo();

            return Banner;
        }


        public List<Modulo> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Modulo.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Modulo.ToList();
        }


    }

}
