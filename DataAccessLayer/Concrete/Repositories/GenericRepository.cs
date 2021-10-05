using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    //her seferinde aynı kontrol işlemlerini yazmamak ve her türlü yapıda kullanabilmek için genel bir sınıf oluşturduk
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T entity)
        {
            var deleteEntity = c.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            //_object.Remove(entity);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //tek değer döndürecek singleofdefault
        }

        public void Insert(T entity)
        {
            var addEntity = c.Entry(entity);
            addEntity.State = EntityState.Added;
            // _object.Add(entity);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            var updateEtity = c.Entry(entity);
            updateEtity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
