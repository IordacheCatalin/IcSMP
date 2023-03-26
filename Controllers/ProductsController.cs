using IcSMP.Models;
using IcSMP.Repositories;
using IcSMP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;

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

        //VIEW SECTION
        public IActionResult Index()
        {
            var products = _productsRepository.GetProducts();
            var supplier = _suppliersRepository.GetSuppliers();
            var category = _categoriesRepository.GetCategories();

            var productViewList = new List<ProductViewModel>();

            foreach(var product in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Category = category?.Where(c => c.Id == product.CategoryId).Select(c => c.Name).FirstOrDefault(),
                    BuyPrice = product.BuyPrice,
                    Caen = product.Caen,
                    Description = product.Description,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    SellPrice = product.SellPrice,
                    SellPriceVat    = product.SellPriceVat,
                    Supplier = supplier?.Where(c => c.Id == product.SupplierId).Select(c => c.CompanyName).FirstOrDefault(),
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                };

                productViewList.Add(productViewModel);
            }

            return View("Index" , productViewList);
        }

        //CREATE SECTION

        public IActionResult Create()
        {
            var supplier = _suppliersRepository.GetSuppliers();
            var category = _categoriesRepository.GetCategories();

            //var categoryList = category.Select(c => new SelectListItem    ------ Varianta cu Select list
            // {
            //     Text = c.Name.ToString(),
            //     Value = c.Id.ToString()
            // }).ToList();

            //ViewBag.dataCategory = categoryList;

            //var supplierList = supplier.Select(c => new SelectListItem   ------ Varianta cu Select list
            //    Text = c.CompanyName.ToString(),
            //    Value = c.Id.ToString()
            //}).ToList();

            //ViewBag.data = supplierList;

            ViewBag.dataCategory = category;
            ViewBag.data = supplier;
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

        //EDIT SECTION
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

        public ProductsRepository Get_productsRepository()
        {
            return _productsRepository;
        }

        //DETAILS SECTION

        [HttpGet]
        public IActionResult Details(int id)
        {
            ProductModel product = _productsRepository.GetProductById(id);
            return View("Details",product);
        }

        //DELETE SECTION

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductModel announcement = _productsRepository.GetProductById(id);
            return View("Delete", announcement);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {

            _productsRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
