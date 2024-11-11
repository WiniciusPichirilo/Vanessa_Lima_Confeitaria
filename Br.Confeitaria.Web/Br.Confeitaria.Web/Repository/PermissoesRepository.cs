using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class PermissoesRepository : GenericRepository<Permissoes>
    {
        public PermissoesRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Permissoes GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Permissoes();

            var Banner = _session.Permissoes.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Permissoes();

            return Banner;
        }

        public Permissoes GetPermissaoById(string Modulo, string NivelId)
        {
         return _session.Permissoes.Where(x => x.Modulo.Id == int.Parse(Modulo) && x.NivelUsuario.Id == int.Parse(NivelId)).FirstOrDefault();
        }

        public List<Permissoes> GetPermissaoByNivelId(string NivelId)
        {
            return _session.Permissoes.Where(x => x.NivelUsuario.Id == int.Parse(NivelId)).ToList();
        }

        public List<Permissoes> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Permissoes.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Permissoes.ToList();
        }


    }

}
