namespace CQRS_LB.Repos
{
    public interface IRepo<T> where T : class
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);


    }
}
