using IcSMP.Models;
using IcSMP.Repositories;
using IcSMP.Services;
using IcSMP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;

namespace IcSMP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _productsRepository;
        private readonly SuppliersRepository _suppliersRepository;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly BrandsRepository _brandsRepository;
        private readonly IMethodsCalculation _methodsCalculation;

        public ProductsController(ProductsRepository productsRepository,
            SuppliersRepository suppliersRepository , 
            CategoriesRepository categoriesRepository,
            BrandsRepository brandsRepository ,
            IMethodsCalculation methodsCalculation)
        {
            _productsRepository = productsRepository;
            _suppliersRepository = suppliersRepository;
            _categoriesRepository = categoriesRepository;
            _methodsCalculation = methodsCalculation;
            _brandsRepository = brandsRepository;
        }

        //VIEW SECTION
        public IActionResult Index()
        {
            var products = _productsRepository.GetProducts();
            var supplier = _suppliersRepository.GetSuppliers();
            var category = _categoriesRepository.GetCategories();
            var brand = _brandsRepository.GetBrands();




            var calculatePriceWithoutVat = _methodsCalculation.calculatePriceWithoutVat;
            var calculateTotal_Sell = _methodsCalculation.calculateTotal_Sell;
            var calculateVat = _methodsCalculation.calculateVat;




            var calculateSumOfColumn_Total_Buy_Whit_Vat_Item = _productsRepository.CalculateAndSave("Buc" , "Buy_Price_Whit_Vat" , "Total_Buy_Whit_Vat_Item");
            var calculateSumOfColumn_TotalBuyItem = _productsRepository.CalculateAndSave("Buc", "BuyPrice", "TotalBuyItem");
            var calculateSumOfColumn_Total_Sell_Item = _productsRepository.CalculateAndSave("Buc", "SellPrice", "Total_Sell_Item");
            var calculateSumOfColumn_Total_Sell_Whit_Vat_Item = _productsRepository.CalculateAndSave("Buc", "SellPriceVat", "Total_Sell_Whit_Vat_Item");


            var calculateSumOfColumn_TotalBuy = _productsRepository.CalculateColumnValueAndSave("TotalBuyItem", "TotalBuy");
            var calculateSumOfColumn_Total_Buy_Whit_Vat = _productsRepository.CalculateColumnValueAndSave("Total_Buy_Whit_Vat_Item", "Total_Buy_Whit_Vat");
            var calculateSumOfColumn_TotalSell = _productsRepository.CalculateColumnValueAndSave("Total_Sell_Item", "TotalSell");
            var calculateSumOfColumn_TotalSellWhitVat = _productsRepository.CalculateColumnValueAndSave("Total_Sell_Whit_Vat_Item", "TotalSellWhitVat");


            var productViewList = new List<ProductViewModel>();
            
            foreach(var product in products)
            {
                var productViewModel = new ProductViewModel()

                {
                    Id = product.Id,
                    Vat = calculateVat(product.Id, product.Buy_Price_Whit_Vat, "Vat"),
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------      

                    Caen = product.Caen,
                    Buc = product.Buc,
                    Description = product.Description,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    Supplier = supplier?.Where(c => c.Id == product.SupplierId).Select(c => c.CompanyName).FirstOrDefault(),
                    Category = category?.Where(c => c.Id == product.CategoryId).Select(c => c.Name).FirstOrDefault(),
                    Brand = brand?.Where(c => c.Id == product.BrandId).Select(c => c.Name).FirstOrDefault(),
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId,

                    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    BuyPrice = calculatePriceWithoutVat(product.Id , product.Buy_Price_Whit_Vat, "BuyPrice"), // ok
                    
                    Buy_Price_Whit_Vat = product.Buy_Price_Whit_Vat, // ok
                    
                    TotalBuyItem = product.TotalBuyItem, //ok

                    Total_Buy_Whit_Vat_Item = product.Total_Buy_Whit_Vat_Item, //ok
                    
                    TotalBuy = product.TotalBuy,  //ok
                    
                    Total_Buy_Whit_Vat = product.Total_Buy_Whit_Vat ,
                  
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    SellPrice = calculatePriceWithoutVat(product.Id, product.SellPriceVat, "SellPrice"),
                    
                    SellPriceVat = product.SellPriceVat,


                    Total_Sell_Item = product.Total_Sell_Item,  
                    
                    Total_Sell_Whit_Vat_Item = product.Total_Sell_Whit_Vat_Item,
                    
                    TotalSell = product.TotalSell, 
                    
                    TotalSellWhitVat = product.TotalSellWhitVat, 
 //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    BuyDate = product.BuyDate,
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
            var brand = _brandsRepository.GetBrands();

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
            ViewBag.dataBrand = brand;
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
