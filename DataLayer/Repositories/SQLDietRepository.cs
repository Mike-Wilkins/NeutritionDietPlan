using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SQLDietRepository : IDietRepository
    {
        private IApplicationDbContext _context;
        public SQLDietRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DietType> Add(DietType diet)
        {
            _context.DietTypes.Add(diet);
            await _context.SaveChangesAsync();
            return diet;
        }

        public async Task<DietType> Delete(int id)
        {
            var diet = await _context.DietTypes.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.DietTypes.Remove(diet);
            await _context.SaveChangesAsync();
            return diet;
        }

        public async Task<IEnumerable<DietType>> GetAllDiets()
        {
            var diets = await _context.DietTypes.OrderBy(m => m.Id).ToListAsync();
            return diets;
        }

        public async Task<DietType> GetDiet(int id)
        {
            var diet = await _context.DietTypes.Where(m => m.Id == id).FirstOrDefaultAsync();
            return diet;
        }

        public DietType Update(DietType diet)
        {
            var dietUpdate = _context.DietTypes.Attach(diet);
            dietUpdate.State = EntityState.Modified;
            _context.SaveChanges();
            return diet;
        }
    }
}
