using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(int id);
    }
}
