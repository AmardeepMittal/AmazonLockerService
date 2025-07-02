using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        Dictionary<string, T> db = new Dictionary<string, T>();
        public Dictionary<string, T> DbSet { get { return db; } }

        public T Add(string id, T entity)
        {
            db.Add(id, entity);
            return entity;
        }

        public T FindById(string id)
        {
            db.TryGetValue(id, out T entity);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return db.Values.AsEnumerable<T>();
        }

        public T Update(string id, T entity)
        {
            if (db.ContainsKey(id) && entity == default) { 
                db.Remove(id);
            }
            db[id] = entity;
            return entity;
        }
    }
}
