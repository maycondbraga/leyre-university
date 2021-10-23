using Leyre.University.Business.Interfaces;
using Leyre.University.Repository.Interfaces.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leyre.University.Business.Core
{
    public class BaseBusiness<TEntity> : IBaseBusiness<TEntity> where TEntity : class
    {
        private IBaseRepository<TEntity> baseRepository;

        public BaseBusiness(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        /// <summary>
        /// Returns all Entities
        /// </summary>
        /// <returns> Entity list </returns>
        public async Task<List<TEntity>> GetAll()
        {
            return await baseRepository.GetAll();
        }

        /// <summary>
        /// Returns Entity based on id
        /// </summary>
        /// <param name="id"> Entity primary key id </param>
        /// <returns> Entity </returns>
        public async Task<TEntity> GetById(int id)
        {
            return await baseRepository.GetById(id);
        }

        /// <summary>
        /// Insert Entity into database
        /// </summary>
        /// <param name="entity"> Entity to insert </param>
        /// <returns> Entity </returns>
        public async Task<TEntity> Insert(TEntity entity)
        {
            return await baseRepository.Insert(entity);
        }

        /// <summary>
        /// Updates Entity into database
        /// </summary>
        /// <param name="entity"> Entity to update </param>
        /// <returns> Entity </returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            return await baseRepository.Update(entity);
        }

        /// <summary>
        /// Delete Entity into database
        /// </summary>
        /// <param name="id"> Entity primary key id </param>
        public async Task Delete(int id)
        {
            await baseRepository.Delete(id);
        }
    }
}
