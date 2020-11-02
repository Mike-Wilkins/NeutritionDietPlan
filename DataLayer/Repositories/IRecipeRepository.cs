using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> Add(Recipe recipe);
        Task<Recipe> Delete(int id);
        Recipe Update(Recipe recipe);
        Task<Recipe> GetRecipe(int id);
        Task<IEnumerable<Recipe>> GetAllRecipies(int id);
        DietType GetDietType(int id);
    }
}
