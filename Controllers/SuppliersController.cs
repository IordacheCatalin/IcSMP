using IcSMP.Repositories;
using Microsoft.AspNetCore.Mvc;
using IcSMP.Models;
using IcSMP.ViewModels;

namespace IcSMP.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SuppliersRepository _supplierRepository;

        public SuppliersController(SuppliersRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        //VIEW SECTION
        public IActionResult Index()
        {
            var suppliers = _supplierRepository.GetSuppliers();
            return View("Index", suppliers);
        }

        //CREATE SECTION

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create (IFormCollection colletions)
        {
            SupplierModel supplier = new SupplierModel();
            if(ModelState.IsValid)
            {
                TryUpdateModelAsync(supplier);
                _supplierRepository.AddSupplier(supplier);
            }
            return RedirectToAction("Index");
        }

        //EDIT SECTION

        public IActionResult Edit(int id) 
        {
            SupplierModel supplier = _supplierRepository.GetSupplierById(id);
            return View("Edit",supplier);
        }
        [HttpPost]

        public IActionResult Edit(int id, IFormCollection colletion)
        {
            SupplierModel supplier = new();
            TryUpdateModelAsync(supplier);
            _supplierRepository.Update(supplier);

            return RedirectToAction("Index");  
        }

        //DETAILS SECTION
        [HttpGet]
        public IActionResult Details(int id) 
        {
            SupplierModel supplier = _supplierRepository.GetSupplierById(id);
            return View("Details", supplier);
        }

        //DELETE SECTION
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            SupplierModel supplier = _supplierRepository.GetSupplierById(id);
            return View("Delete", supplier);
        }

        [HttpPost]
        public IActionResult Delete (int id , IFormCollection collection)
        {
            _supplierRepository.Delete(id);
            return RedirectToAction("Index");
        }        
    }
}
