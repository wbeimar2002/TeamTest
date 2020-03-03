namespace TeamTest.Repositories.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using TeamTest.Models.Entities;

    public class SpaRepository<T> : ISpaRepository<T> where T : EntityBase
    {
        private readonly SpaContext _dbContext;
        public SpaRepository()
        {
            _dbContext = new SpaContext();
        }
        public bool Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            var changes = _dbContext.SaveChanges();

            return changes > 0;
        }

        public bool Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            var changes = _dbContext.SaveChanges();

            return changes > 0;
        }

        public bool Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            var changes = _dbContext.SaveChanges();

            return changes > 0;
        }

        public bool Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var changes = _dbContext.SaveChanges();

            return changes > 0;
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
    }
}
