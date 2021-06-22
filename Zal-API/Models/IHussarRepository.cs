using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zal_API.Models
{
    public interface IHussarRepository<T> where T : class
    {
        Task<T> AddEntity(T entity);
        Task<IEnumerable<T>> GetAllEntities();
        Task<T> GetEntity(int id);
        Task<T> EditEntity(T entity);
        Task DeleteEntity(T entity);

    }
}
