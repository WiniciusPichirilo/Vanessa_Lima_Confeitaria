using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class TamanhoRepository : GenericRepository<Tamanho>
    {
        public TamanhoRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Tamanho GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Tamanho();

            var Banner = _session.Tamanho.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Tamanho();

            return Banner;
        }


        public List<Tamanho> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Tamanho.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Tamanho.ToList();
        }


    }

}
