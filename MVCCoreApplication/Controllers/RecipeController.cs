using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreApplication.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeRepository _db;
        public RecipeController(IRecipeRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int id)
        {
            var dietType = _db.GetDietType(id);
            ViewBag.DietType_Id = dietType.Id;
            ViewBag.DietType_Name = dietType.Name;

            var recipeList = await _db.GetAllRecipies(id);
            return View(recipeList);
        }

        //GET: Create
        public IActionResult Create(int id)
        {
            var dietType = _db.GetDietType(id);
            ViewBag.DietType_Id = dietType.Id;
            ViewBag.DietType_Name = dietType.Name;

            return View();
        }
        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe, int id)
        {
            var dietType = _db.GetDietType(id);
            ViewBag.DietType_Id = dietType.Id;
            ViewBag.DietType_Name = dietType.Name;

            recipe.DietId = id;
            recipe.Id = 0;
            await _db.Add(recipe);

            var recipeList = await _db.GetAllRecipies(id);

            return View("Index", recipeList);
        }
        //GET: Delete
        // POST : Delete
    }
}
