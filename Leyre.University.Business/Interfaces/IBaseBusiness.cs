using System.Threading.Tasks;
using System.Collections.Generic;

namespace Leyre.University.Business.Interfaces
{
    /// <summary>
    /// Base interface for basic methods
    /// </summary>
    /// <typeparam name="TEntity"> T Entity </typeparam>
    public interface IBaseBusiness<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);
    }
}
