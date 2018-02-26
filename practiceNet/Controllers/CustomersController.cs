using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practiceNet.Models;

namespace practiceNet.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //SingleOrDefault -> para seleccionar un objeto que concuerde con la condicional
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    //    private IEnumerable<Customer> GetCustomers()
    //    {

    //        return new List<Customer>
    //        {
    //            new Customer { Id=1, Name = "Jhonatan Rojas"},
    //            new Customer { Id=2, Name = "Renan Romero"}
    //        };
    //    }
    }
}