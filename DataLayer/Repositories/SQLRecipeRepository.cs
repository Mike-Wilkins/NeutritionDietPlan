using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SQLRecipeRepository : IRecipeRepository
    {
        private IApplicationDbContext _context;
        public SQLRecipeRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Recipe> Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipies(int id)
        {
            var recipeList = await _context.Recipes.Where(m => m.DietId == id).ToListAsync();
            return recipeList;
        }

        public Recipe Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public DietType GetDietType(int id)
        {
            DietType diet = _context.DietTypes.Where(m => m.Id == id).FirstOrDefault();
            return diet;
        }
    }
}
