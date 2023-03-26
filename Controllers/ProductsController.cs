using IcSMP.Models;
using IcSMP.Repositories;
using IcSMP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace IcSMP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _productsRepository;
        private readonly SuppliersRepository _suppliersRepository;
        private readonly CategoriesRepository _categoriesRepository;

        public ProductsController(ProductsRepository productsRepository,SuppliersRepository suppliersRepository , CategoriesRepository categoriesRepository)
        {
            _productsRepository = productsRepository;
            _suppliersRepository = suppliersRepository;
            _categoriesRepository = categoriesRepository;
        }

        public IActionResult Index()
        {
            var products = _productsRepository.GetProducts();
            return View("Index" , products);
        }

        public IActionResult Create()
        {
            var supplier = _suppliersRepository.GetSuppliers();
            var category = _categoriesRepository.GetCategories();
            ViewBag.data = supplier;
            ViewBag.dataCategory = category;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            ProductModel product = new ProductModel(); 
            if(ModelState.IsValid)
            {
                TryUpdateModelAsync(product);
                _productsRepository.AddProduct(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ProductModel product = _productsRepository.GetProductById(id);
            return View("Edit",product);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            ProductModel product = new();
            TryUpdateModelAsync(product);
            _productsRepository.UpdateProduct(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            ProductModel product = _productsRepository.GetProductById(id);
            return View("Details", product);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productsRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsWithCategory(int id)
        {
            CategoryViewModel viewModel = _productsRepository.GetProductCategory(id);
            return View("DetailsWithCategory", viewModel);
        }

        public IActionResult DetailsWithSuppliers(int id)
        {
            SupplierViewModel viewModel = _productsRepository.GetProductSuplier(id);
            return View("DetailsWithSuppliers", viewModel);
        }
    }
}
