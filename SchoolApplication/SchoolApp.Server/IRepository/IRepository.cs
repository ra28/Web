using SchoolApp.Server.Models.DataObject;
using System.Collections.Generic;


namespace SchoolApp.Server.IRepository
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();

        T GetByID(int id);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

    }
}
