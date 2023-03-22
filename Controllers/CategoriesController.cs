using IcSMP.Repositories;
using Microsoft.AspNetCore.Mvc;
using IcSMP.Models;
using System.Globalization;

namespace IcSMP.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly CategoriesRepository _repository;

        public CategoriesController(CategoriesRepository repository)
        {
            _repository = repository;
        }

        //VIEW SECTION
        public IActionResult Index()
        {
            var categories = _repository.GetCategories();
            return View("Index", categories);
        }

        //CREATE SECTION

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            CategoryModel category = new CategoryModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(category);// maps the data from the form filled in by the user to the category model
                _repository.AddCategory(category);
            }
            return RedirectToAction("Index");
        }

        //EDIT SECTION

        public IActionResult Edit(int id)
        {
            CategoryModel category = _repository.GetCatagoryById(id);

            return View("Edit", category);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            CategoryModel category = new();
            TryUpdateModelAsync(category);
            _repository.Update(category);

            return RedirectToAction("Index");
        }
    }
}
