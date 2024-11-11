using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class ClientesRepository : GenericRepository<Clientes>
    {
        public ClientesRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Clientes GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Clientes();

            var Banner = _session.Clientes.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Clientes();

            return Banner;
        }

        public List<Clientes> GetAll(string status = "", string Id = "")
        {
            if (!string.IsNullOrEmpty(status))
                return _session.Clientes.Where(x => x.Status == int.Parse(status)).ToList();

            if (!string.IsNullOrEmpty(Id))
                return _session.Clientes.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Clientes.ToList();
        }

        public Clientes GetByEmailAndPassword(string Email, string Senha)
        {

            var Clientes = _session.Clientes.Where(x => x.Email == Email && x.Senha == Senha).FirstOrDefault();

            if (Clientes == null)
                Clientes = new Clientes();

            return Clientes;
        }


    }

}
