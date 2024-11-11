

using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class AjudaRepository: GenericRepository<Ajuda>
    {
        public AjudaRepository(ClassDBContext contexto) : base(contexto)
        {
        }

        public Ajuda GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Ajuda();

            var Banner = _session.Ajuda.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Ajuda();

            return Banner;
        }


        public List<Ajuda> GetAll(string status = "", string Id = "")
        {
            if (!string.IsNullOrEmpty(status))
                return _session.Ajuda.Where(x => x.Status == int.Parse(status)).ToList();

            if (!string.IsNullOrEmpty(Id))
                return _session.Ajuda.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Ajuda.ToList();
        }


    }

}
