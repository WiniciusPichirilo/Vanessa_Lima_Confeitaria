using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{
    public class CandidaturasRepository : GenericRepository<Candidaturas>
    {
        public CandidaturasRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Candidaturas GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Candidaturas();

            var Candidaturas = _session.Candidaturas.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Candidaturas == null)
                Candidaturas = new Candidaturas();

            return Candidaturas;
        }

        public List<Candidaturas> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Candidaturas.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Candidaturas.ToList();
        }
    }
}
