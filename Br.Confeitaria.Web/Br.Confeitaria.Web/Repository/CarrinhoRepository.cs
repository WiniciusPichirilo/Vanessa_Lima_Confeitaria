using Br.Confeitaria.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{
    public class CarrinhoRepository
    {
        public IHttpContextAccessor contextAccessor;
        public CarrinhoRepository(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public void AddCarrinho(Carrinho carrinho)
        {
            SetPedidoId(carrinho);
        }

        public List<Carrinho> GetCarrinho()
        {
            try
            {
                if (!string.IsNullOrEmpty(contextAccessor.HttpContext.Session.GetString("Carrinho")))
                {
                    return JsonConvert.DeserializeObject<List<Carrinho>>(contextAccessor.HttpContext.Session.GetString("Carrinho"));
                }

            }
            catch (Exception e)
            {

            }

            return new List<Carrinho>();
        }

        private void SetPedidoId(Carrinho carrinho)
        {

            List<Carrinho> lista = GetCarrinho();



            var Existe = lista.Where(x => x.ProdutoId == carrinho.ProdutoId).ToList();

            if (Existe.Count > 0)
            {
                for (var index = 0; index < lista.Count; index++)
                {
                    if (lista[index].ProdutoId == carrinho.ProdutoId)
                    {
                        lista[index].Quantidade = carrinho.Quantidade;

                        if (!string.IsNullOrEmpty(carrinho.Cupom))
                        {
                            lista[index].Desconto = carrinho.Desconto;
                            lista[index].Cupom = carrinho.Cupom;
                        }
                    }

                }
            }
            else
            {

                lista.Add(carrinho);
            }

            var json = JsonConvert.SerializeObject(lista, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );

            contextAccessor.HttpContext.Session.SetString("Carrinho", json);

        }

        public void LimpaCarrinho()
        {
            contextAccessor.HttpContext.Session.SetString("Carrinho", "");
        }
    }
}
