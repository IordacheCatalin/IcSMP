using IcSMP.Models;
using IcSMP.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        //VIEW SECTION
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
    }
}
