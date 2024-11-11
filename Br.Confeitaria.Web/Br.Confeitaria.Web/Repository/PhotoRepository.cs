using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web.Repository
{

    public class PhotoRepository : GenericRepository<Photo>
    {
        public PhotoRepository(ClassDBContext contexto) : base(contexto)
        {
        }
        public Photo GetId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new Photo();

            var Banner = _session.Photo.Where(x => x.Id == int.Parse(Id)).FirstOrDefault();

            if (Banner == null)
                Banner = new Photo();

            return Banner;
        }

        public List<Photo> GetByProductId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return new List<Photo>();

            var Photos = _session.Photo.Where(x => x.Produto.Id == int.Parse(Id)).ToList();

            return Photos;
        }


        public List<Photo> GetAll(string Id="")
        {
        
            if (!string.IsNullOrEmpty(Id))
                return _session.Photo.Where(x => x.Id == int.Parse(Id)).ToList();

            return _session.Photo.ToList();
        }


    }

}
