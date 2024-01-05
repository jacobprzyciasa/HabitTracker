namespace HabitTracker.Api.Services
{
    public interface IEntityServiceBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
