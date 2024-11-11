
using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class PaymentRepository : GenericRepository<Pagamento>
    {
        public PaymentRepository(ClassDBContext contexto) : base(contexto)
        {
        }

        public Pagamento GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Pagamento();

            var Banner = _session.Pagamento.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Pagamento();

            return Banner;
        }


        public List<Pagamento> GetAll(string status = "", string Id = "")
        {
         
            if (!string.IsNullOrEmpty(Id))
                return _session.Pagamento.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Pagamento.ToList();
        }


    }

}
