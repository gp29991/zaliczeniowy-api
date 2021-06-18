using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal_API.Data;

namespace Zal_API.Models
{
    public class HussarRepository : IHussarRepository
    {
        private readonly DataContext _context;

        public HussarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Hussar> AddHussar(Hussar hussar)
        {
            _context.Hussars.Add(hussar);
            await _context.SaveChangesAsync();
            return hussar;
        }

        public async Task<IEnumerable<Hussar>> GetAllHussars()
        {
            return await _context.Hussars.ToListAsync();
        }

        public async Task<Hussar> GetHussar(int id)
        {
            return await _context.Hussars.FindAsync(id);
        }

        public async Task<Hussar> EditHussar(Hussar hussar)
        {
            _context.Hussars.Update(hussar);
            await _context.SaveChangesAsync();
            return hussar;
        }

        public async Task DeleteHussar(Hussar hussar)
        {
            _context.Hussars.Remove(hussar);
            await _context.SaveChangesAsync();
        }
    }
}
