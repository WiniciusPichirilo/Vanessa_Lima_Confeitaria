using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{
    public class VagasRepository : GenericRepository<Vagas>
    {
        public VagasRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Vagas GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Vagas();

            var Vagas = _session.Vagas.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Vagas == null)
                Vagas = new Vagas();

            return Vagas;
        }

        public List<Vagas> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Vagas.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Vagas.ToList();
        }
    }
}
