using Microsoft.EntityFrameworkCore;
using WebAppDocker.Database.Entities;

namespace WebAppDocker.Database.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly WebAppDockerDbContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(WebAppDockerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity AddAsync(TEntity entity)
        {
            _dbSet.Add(entity); 
            _context.SaveChanges();
            return entity;
        }
        public async Task<TEntity> Find(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return  _dbSet.ToList();
        }
        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
