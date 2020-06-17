
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomCategoryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace RoomCategoryAPI.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RoomCategoryContext _context;
        public Repository(RoomCategoryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetBy(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}