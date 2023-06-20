using IcSMP.Models;
using IcSMP.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IcSMP.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandsRepository _brandsRepository;

        public BrandController(BrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        public IActionResult Index()
        {
            var brand = _brandsRepository.GetBrands();
            return View("Index", brand);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection colletions)
        {
            BrandModel brand = new BrandModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(brand);
                _brandsRepository.AddBrand(brand);
            }
            return RedirectToAction("Index");
        }

        //EDIT SECTION

        public IActionResult Edit(int id)
        {
            BrandModel brand = _brandsRepository.GetBrandById(id);
            return View("Edit", brand);
        }
        [HttpPost]

        public IActionResult Edit(int id, IFormCollection colletion)
        {
            BrandModel brand = new();
            TryUpdateModelAsync(brand);
            _brandsRepository.Update(brand);

            return RedirectToAction("Index");
        }

        //DETAILS SECTION
        [HttpGet]
        public IActionResult Details(int id)
        {
            BrandModel brand = _brandsRepository.GetBrandById(id);
            return View("Details", brand);
        }

        //DELETE SECTION
        [HttpGet]
        public IActionResult Delete(int id)
        {
            BrandModel brand = _brandsRepository.GetBrandById(id);
            return View("Delete", brand);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _brandsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
