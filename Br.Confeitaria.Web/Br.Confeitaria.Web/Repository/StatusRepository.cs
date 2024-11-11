
using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class StatusRepository : GenericRepository<Status>
    {
        public StatusRepository(ClassDBContext contexto) : base(contexto)
        {
        }

        public Status GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Status();

            var Banner = _session.Status.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Status();

            return Banner;
        }


        public List<Status> GetAll(string status = "", string Id = "")
        {

            if (!string.IsNullOrEmpty(Id))
                return _session.Status.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Status.ToList();
        }


    }

}
