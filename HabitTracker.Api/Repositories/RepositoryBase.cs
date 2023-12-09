using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Api.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbcontext;

        public RepositoryBase(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public virtual void Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbcontext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public virtual void Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
        }

        public virtual int Save()
        {
            return _dbcontext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbcontext.Update(entity);
        }
    }
}
