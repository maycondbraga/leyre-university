using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leyre.University.Repository.Interfaces.Core
{
    /// <summary>
    /// Base interface for basic methods
    /// </summary>
    /// <typeparam name="TEntity"> T Entity </typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);
    }
}
