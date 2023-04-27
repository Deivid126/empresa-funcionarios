using CRUD_empresas.Database;
using CRUD_empresas.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_empresas.Repositorys
{
    public class BaseRepository : IBaseRepository
    {

        public readonly ContextDB _context;

        public BaseRepository(ContextDB context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
             _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
