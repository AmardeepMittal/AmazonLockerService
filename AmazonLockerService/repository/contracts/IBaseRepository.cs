using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLockerService.repository
{
    public interface IBaseRepository<T> where T : class
    {
        Dictionary<string, T> DbSet { get;}
        IEnumerable<T> GetAll();
        T FindById(string id);
        T Add(string id, T entity);
        T Update(string id, T entity);
    }
}
