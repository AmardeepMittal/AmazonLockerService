using AmazonLockerService.models;
using AmazonLockerService.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository.inMemory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        Dictionary<int, T> db = new Dictionary<int, T>();        
        private readonly IDGenerator generator = new IDGenerator();
        public Dictionary<int, T> DbSet { get { return db; } }

        public T Add(T entity)
        {
            //Id will be returned from DB when entity is added.
            //In this case, we assume entity has a property Id of type string.
            int id = generator.GenerateId();
            entity.Id = id;
            db.Add(id, entity);
            return entity;
        }

        public T FindById(int id)
        {
            db.TryGetValue(id, out T entity);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return db.Values.AsEnumerable<T>();
        }

        public T Update(int id, T entity)
        {
            if (db.ContainsKey(id) && entity == default) { 
                db.Remove(id);
            }
            db[id] = entity;
            return entity;
        }
    }
}
