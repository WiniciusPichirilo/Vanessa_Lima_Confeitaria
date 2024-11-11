

using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class PedidoRepository: GenericRepository<Pedido>
    {
        public PedidoRepository(ClassDBContext contexto) : base(contexto)
        {
        }

        public Pedido GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Pedido();

            var Banner = _session.Pedido
              .Include(x => x.Pagamento)
              .Include(x => x.Status)
              .Include(x => x.ItemPedido)
              .ThenInclude(x => x.Produto)
              .Include(x => x.Cliente)
              .Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Pedido();

            return Banner;
        }


        public List<Pedido> GetAll(string status = "", string Id = "")
        {
            if (!string.IsNullOrEmpty(status))
                return _session.Pedido.Where(x => x.Status.Id == int.Parse(status)).ToList();

            if (!string.IsNullOrEmpty(Id))
                return _session.Pedido.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Pedido.ToList();
        }


    }

}
