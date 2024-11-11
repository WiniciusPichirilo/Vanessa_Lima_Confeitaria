using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class NewslatterRepository : GenericRepository<Newslatter>
    {
        public NewslatterRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Newslatter GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Newslatter();

            var Banner = _session.Newslatter.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Newslatter();

            return Banner;
        }

        public bool GetByEmail(string Email)
        {
           
            var Banner = _session.Newslatter.Where(x => x.Email.Contains(Email)).FirstOrDefault();

            if (Banner !=null)
                return true;

            return false;
        }


        public List<Newslatter> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Newslatter.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Newslatter.ToList();
        }


    }

}
