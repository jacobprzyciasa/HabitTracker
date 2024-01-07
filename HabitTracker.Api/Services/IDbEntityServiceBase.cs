namespace HabitTracker.Api.Services
{
    public interface IDbEntityServiceBase<T1, T2>
    {
        IEnumerable<T1> GetAll();
        T1 GetById(int id);
        T1 Add(T2 entity);
        void Delete(T1 entity);
        T1 Update(T1 entity);

    }
}
