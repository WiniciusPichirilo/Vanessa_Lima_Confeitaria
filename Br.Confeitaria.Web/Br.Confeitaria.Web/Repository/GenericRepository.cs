using Br.Confeitaria.Web.Models;
using Br.Confeitaria.Web.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace Br.Confeitaria.Web.Repository
{
   

    public abstract class GenericRepository<T> where T : class
    {

        public ClassDBContext _session;
        private DbSet<T> entities;
        public GenericRepository(ClassDBContext context)
        {
            this._session = context;
            entities = context.Set<T>();
        }


        public void ToDelete(T entidade)
        {

            entities.Remove(entidade);
            _session.SaveChanges();
        }

        public T ToSave(T entidade)
        {

            entities.Add(entidade);
            _session.SaveChanges();

            return entidade;
        }

        public void ToUpdate(T entidade)
        {
            entities.Update(entidade);
            _session.SaveChanges();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public async Task ToSaveAsync(T entidade)
        {
            entities.Add(entidade);
            await _session.SaveChangesAsync();
        }

        public async Task ToUpdateAsync(T entidade)
        {
            entities.Update(entidade);
            await _session.SaveChangesAsync();
        }


    }
}