using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreApplication.Controllers
{
    public class DietController : Controller
    {
        private IDietRepository _db;
        public DietController(IDietRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var dietList = await _db.GetAllDiets();
            return View(dietList);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(DietType diet)
        {
            if (!ModelState.IsValid)
            {
                return View(diet);
            }
            await _db.Add(diet);
            var dietList = await _db.GetAllDiets();
            return View("Index", dietList);
        }
        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var diet = await _db.GetDiet(id);
            return View(diet);
        }
    
        // POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            await _db.Delete(id);
            var dietList = await _db.GetAllDiets();
            return View("Index", dietList);
        }

        //GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var updateDiet = await _db.GetDiet(id);
            return View(updateDiet);
        }
        //POST: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(DietType diet)
        {
            _db.Update(diet);
            var dietList = await _db.GetAllDiets();
            return View("Index", dietList);
        }
       
    }
}
