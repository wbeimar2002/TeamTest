namespace TeamTest.Repositories.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TeamTest.Models.Entities;
    public interface ISpaRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        bool Add(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
        public bool Update(T entity);
    }
}
