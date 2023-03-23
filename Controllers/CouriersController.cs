using IcSMP.Repositories;
using Microsoft.AspNetCore.Mvc;
using IcSMP.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IcSMP.Controllers
{
    public class CouriersController : Controller
    {
        public readonly CouriersRepository _couriersRepository;

        public CouriersController(CouriersRepository couriersRepository)
        {
            _couriersRepository = couriersRepository;
        }

        //VIEW SECTION
        public IActionResult Index()
        {
            var couriers = _couriersRepository.GetCouriers();
            return View("Index", couriers);
        }

        //Create section

        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            CourierModel courier = new CourierModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(courier);
                _couriersRepository.AddCourier(courier);
            }
            return RedirectToAction("Index");
        }

        //Edit section
        public IActionResult Edit(int id)
        {
            CourierModel courier = _couriersRepository.GetCourierById(id);
            return View("Edit", courier);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            CourierModel courier = new();
            TryUpdateModelAsync(courier);
            _couriersRepository.Update(courier);

            return RedirectToAction("Index");
        }

        //Details section
       public IActionResult Details(int id)
        {
            CourierModel courier = _couriersRepository.GetCourierById(id);
            return View("Details", courier);
        }

        //Delete section
        [HttpGet]
        public IActionResult Delete(int id)
        {
            CourierModel courier = _couriersRepository.GetCourierById(id);
            return View("Delete", courier);
        }

        [HttpPost]

        public IActionResult Delete(int id, IFormCollection collection)
        {
            _couriersRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
