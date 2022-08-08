using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Entities.Dtos;
using BusinessLogic.Service;

namespace MVCExample.Controllers
{
    public class ClientController : Controller
    {

        public ClientController(IClientService ClientService)
        {
            this.ClientService = ClientService;
        }

        public IClientService ClientService { get; private set; }

        // GET: Client
        public IActionResult Index()
        {
            return View(ClientService.GetAll());
        }

        // GET: Client/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var client = ClientService.GetById(Convert.ToInt32(id));

            if (client == null)
                return NotFound();

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,LastName,IdentificationNumber")] ClientDto client)
        {
            if (!ModelState.IsValid)
                return View(client);

            ClientService.Create(client);
            return RedirectToAction(nameof(Index));
        }

        // GET: Client/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var client = ClientService.GetById(Convert.ToInt32(id));

            if (client == null)
                return NotFound();

            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,LastName,IdentificationNumber")] ClientDto client)
        {
            if (id != client.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(client);

            ClientService.Update(client);

            return RedirectToAction(nameof(Index));
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var client = ClientService.GetById(Convert.ToInt32(id));

            if (client == null)
                return NotFound();

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ClientService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
