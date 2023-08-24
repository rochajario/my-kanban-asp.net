using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repsitories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            _context = (ApplicationContext)unitOfWork!;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _context.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id)!;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            var item = Get((int)entity.Id!);
            if (item == null)
            {
                return;
            }

            _context.Entry(item).CurrentValues.SetValues(entity);
        }
    }
}
