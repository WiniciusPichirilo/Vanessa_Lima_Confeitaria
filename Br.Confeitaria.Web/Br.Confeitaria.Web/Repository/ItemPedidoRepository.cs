

using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class ItemPedidoRepository: GenericRepository<ItemPedido>
    {
        public ItemPedidoRepository(ClassDBContext contexto) : base(contexto)
        {
        }

        public ItemPedido GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new ItemPedido();

            var Banner = _session.ItemPedido.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new ItemPedido();

            return Banner;
        }


        public List<ItemPedido> GetAll( string Id = "")
        {
           
            if (!string.IsNullOrEmpty(Id))
                return _session.ItemPedido.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.ItemPedido.ToList();
        }


    }

}
