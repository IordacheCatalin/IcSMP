using IcSMP.Models;
using IcSMP.Repositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace IcSMP.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientsRepository _clientRepository;
        public ClientsController(ClientsRepository repository) 
        {
            _clientRepository = repository;
        }
        //VIEW SECTION
        public IActionResult Index()
        {
            var clients = _clientRepository.GetClients();
            return View("Index", clients);
        }

        //CREATE SECTION
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]

        public IActionResult Create(IFormCollection collection)
        {
            ClientModel client = new ClientModel();
            TryUpdateModelAsync(client);
            _clientRepository.AddClient(client);

            return RedirectToAction("Index");
        }

        //EDIT SECTION

        public IActionResult Edit(int id)
        {
            ClientModel client = _clientRepository.GetClientById(id);

            return View("Edit", client);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            ClientModel client = new();
            TryUpdateModelAsync(client);
            _clientRepository.Update(client);

            return RedirectToAction("Index");
        }

        //DETAILS SECTION
        [HttpGet]
        public IActionResult Details(int id)
        {
            ClientModel client = _clientRepository.GetClientById(id);
            return View("Details", client);
        }

        //DELETE SECTION
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ClientModel client = _clientRepository.GetClientById(id);
            return View("Delete", client);
        }


        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _clientRepository.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
