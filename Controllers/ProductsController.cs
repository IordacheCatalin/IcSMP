using IcSMP.Models;
using IcSMP.Repositories;
using IcSMP.Services;
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
        private readonly IMethodsCalculation _methodsCalculation;

        public ProductsController(ProductsRepository productsRepository,
            SuppliersRepository suppliersRepository , 
            CategoriesRepository categoriesRepository,
            IMethodsCalculation methodsCalculation)
        {
            _productsRepository = productsRepository;
            _suppliersRepository = suppliersRepository;
            _categoriesRepository = categoriesRepository;
            _methodsCalculation = methodsCalculation;
        }

        //VIEW SECTION
        public IActionResult Index()
        {
            var products = _productsRepository.GetProducts();
            var supplier = _suppliersRepository.GetSuppliers();
            var category = _categoriesRepository.GetCategories();
            var methodCalculation = _methodsCalculation.CalculateVat;

            var productViewList = new List<ProductViewModel>();

            foreach(var product in products)
            {
                var productViewModel = new ProductViewModel()

                {
                    Id = product.Id,                   
                    BuyPrice = product.BuyPrice,
                    Caen = product.Caen,
                    Buc = product.Buc,
                    Description = product.Description,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    SellPrice = product.SellPrice,
                    SellPriceVat = _methodsCalculation.CalculateVat(product.SellPrice),
                    //SellPriceVat = (product.SellPrice * 19 / 100) + product.SellPrice,
                    Supplier = supplier?.Where(c => c.Id == product.SupplierId).Select(c => c.CompanyName).FirstOrDefault(),
                    Category = category?.Where(c => c.Id == product.CategoryId).Select(c => c.Name).FirstOrDefault(),
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    TotalBuy = _methodsCalculation.calculateTotalBuy(product.BuyPrice, product.Buc), /*Total buy = suma tuturor preturilor de intrare ori nr de buc */
                    //Vat = product.Vat, 
                    //TotalSell = product.TotalSell, /*Total sell = Suma tuturor preturilor de vanzare fara tva ori nr de buc */
                    //TotalSellWhitVat = product.TotalSellWhitVat, /*Total sell whit vat = Suma tuturor preturilor de vanzare cu tva ori nr de buc */
                    //TotalBuyItem = product.TotalBuyItem, /*Total buy item = Pretul de intrare* nr de buc*/
                    //Total_Sell_Item = product.Total_Sell_Item,  /*Total sell item = Pretul de vanzare fara tva * nr de buc*/
                    //Total_Sell_Whit_Vat_Item = product.Total_Sell_Whit_Vat_Item /*Total sell whit vat item = Pretul de vanzare cu tva * nr de buc*/
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
