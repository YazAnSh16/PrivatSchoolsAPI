using CQRS_LB.Data;

namespace CQRS_LB.Repos
{
    public class MainRepo<T> : IRepo<T> where T : class
    {


        public MainRepo(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;

        public Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Entity with id {id} not found.");
            }
        }

        public Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // we use IQueryable to allow for deferred execution and better performance when filtering or projecting data

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}
