using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class NivelUsuarioRepository : GenericRepository<NivelUsuario>
    {
        public NivelUsuarioRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public NivelUsuario GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new NivelUsuario();

            var Banner = _session.NivelUsuario.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new NivelUsuario();

            return Banner;
        }


        public List<NivelUsuario> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.NivelUsuario.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.NivelUsuario.ToList();
        }


    }

}
