using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal_API.Data;

namespace Zal_API.Models
{
    public class HussarRepository<T> : IHussarRepository<T> where T : class
    {
        private readonly DataContext _context;

        public HussarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllEntities()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntity(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> EditEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
