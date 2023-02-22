using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace WebAppDapper.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepositories _customerRepositories;
        public CustomersController(ICustomerRepositories customerRepositories)
        {
            _customerRepositories = customerRepositories;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var model = _customerRepositories.GetCustomers();

            return View(model);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var model = _customerRepositories.GetCustomer((long)id );
            return View(model);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDto customer)
        {
            try
            {
                var result = _customerRepositories.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _customerRepositories.GetCustomer((long)id);
            return View(model);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerDto customer)
        {
            try
            {
                var result = _customerRepositories.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _customerRepositories.GetCustomer((long)id);
            return View(model);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var result = _customerRepositories.Delete((long)id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
