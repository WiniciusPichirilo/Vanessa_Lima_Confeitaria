using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class UsuariosRepository : GenericRepository<Usuarios>
    {
        public UsuariosRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Usuarios GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Usuarios();

            var Banner = _session.Usuarios.Include(x => x.NivelUsuario).Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Usuarios();

            return Banner;
        }

        public Usuarios GetByUser(string User, string Senha)
        {
            return _session.Usuarios
                .Include(x => x.NivelUsuario)
                .Include(x => x.NivelUsuario.Permissoes)
                .ThenInclude(x => x.Modulo)
                .Where(x => x.Email == User && x.Senha == Senha)
                .FirstOrDefault();
        }


        public List<Usuarios> GetAll(string Status = "",string Id="")
        {
            var Lista = _session.Usuarios.Include(x => x.NivelUsuario).ToList();


            if (!string.IsNullOrEmpty(Id))
                return Lista.Where(x => x.Id == int.Parse(Id)).ToList();

            if (!string.IsNullOrEmpty(Status))
                return Lista.Where(x => x.Status == int.Parse(Status)).ToList();


            return Lista;
        }


    }

}
