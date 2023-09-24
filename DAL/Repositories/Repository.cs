using DataAccessLayer.IRepositories;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            SaveChanges();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
