using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class ContatoRepository : GenericRepository<Contato>
    {
        public ContatoRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Contato GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Contato();

            var Banner = _session.Contato.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Contato();

            return Banner;
        }

        public List<Contato> GetAll(string Lido="", string Id="")
        {
            if(!string.IsNullOrEmpty(Lido))
                return _session.Contato.Where(x => x.Lido == int.Parse(Lido)).ToList();

            if (!string.IsNullOrEmpty(Id))
                return _session.Contato.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Contato.ToList();
        }


    }

}
