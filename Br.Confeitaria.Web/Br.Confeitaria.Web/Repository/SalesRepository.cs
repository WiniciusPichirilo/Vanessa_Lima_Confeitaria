

using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class SalesRepository: GenericRepository<Sales>
    {
        public SalesRepository(ClassDBContext contexto) : base(contexto)
        {
        }

        public Sales GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Sales();

            var Banner = _session.Sales.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Sales();

            return Banner;
        }


        public List<Sales> GetAll(DateTime Init , DateTime End, string status)
        {
            if (!string.IsNullOrEmpty(status))
                return _session.Sales.Where(x => x.Status == status).ToList();

            if(Init.Date != DateTime.MinValue && End.Date != DateTime.MinValue){
                return _session.Sales.Where(x => x.CreatedAt >= Init && x.CreatedAt <= End).ToList();
            }

            return _session.Sales.ToList();
        }


    }

}
