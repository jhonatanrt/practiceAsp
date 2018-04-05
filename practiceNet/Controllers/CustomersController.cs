using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practiceNet.Models;
using practiceNet.ViewModels;

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

        public ActionResult New()
        {
            var membershiptypes = _context.MembershipType.ToList();
            var viewModel = new CustomerForViewModel
            {
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0){
                _context.Customers.Add(customer);
            } else {
                var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //Mapper.Map(customer, CustomerInDb);
                CustomerInDb.Name = customer.Name;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                CustomerInDb.Birthdate = customer.Birthdate;

            }
            
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Customers");
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
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerForViewModel
            {
                Customer = customers,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("CustomerForm", viewModel);
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