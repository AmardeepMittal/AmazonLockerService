using AmazonLockerService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Dictionary<int, T> DbSet { get;}
        IEnumerable<T> GetAll();
        T FindById(int id);
        T Add(T entity);
        T Update(int id, T entity);
    }
}
