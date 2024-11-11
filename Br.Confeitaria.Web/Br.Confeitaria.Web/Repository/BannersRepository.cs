using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class BannersRepository: GenericRepository<Banners>
    {
        public BannersRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Banners GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Banners();

            var Banner = _session.Banners.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Banners();

            return Banner;
        }

        public List<Banners> GetAll(string status="", string Id="")
        {
            
            if (!string.IsNullOrEmpty(status))
                return _session.Banners.Where(x => x.Status == int.Parse(status)).ToList();

            if (!string.IsNullOrEmpty(Id))
                return _session.Banners.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Banners.ToList();
        }


    }

}
