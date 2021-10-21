using Leyre.University.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leyre.University.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Leyre.University.Repository.Repositories.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly UniversityContext universityContext;

        public BaseRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }

        /// <summary>
        /// Returns the total number of Entities
        /// </summary>
        /// <returns> Int </returns>
        public int Count()
        {
            return universityContext.Set<TEntity>().ToList().Count;
        }

        /// <summary>
        /// Returns all Entities
        /// </summary>
        /// <returns> Entity list </returns>
        public async Task<List<TEntity>> GetAll()
        {
            return await universityContext.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Returns Entity based on id
        /// </summary>
        /// <param name="id"> Entity primary key id </param>
        /// <returns> Entity </returns>
        public async Task<TEntity> GetById(int id)
        {
            return await universityContext.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Insert Entity into database
        /// </summary>
        /// <param name="entity"> Entity to insert </param>
        /// <returns> Entity </returns>
        public async Task<TEntity> Insert(TEntity entity)
        {
            await universityContext.Set<TEntity>().AddAsync(entity);
            await universityContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates Entity into database
        /// </summary>
        /// <param name="entity"> Entity to update </param>
        /// <returns> Entity </returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            universityContext.Set<TEntity>().Update(entity);
            await universityContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Delete Entity into database
        /// </summary>
        /// <param name="id"> Entity primary key id </param>
        /// <exception cref="Exception"> The entity is null </exception>
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("The entity is null");
            }

            universityContext.Set<TEntity>().Remove(entity);
            await universityContext.SaveChangesAsync();
        }
    }
}
