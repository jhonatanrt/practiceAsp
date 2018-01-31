﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practiceNet.Models;

namespace practiceNet.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //SingleOrDefault -> para seleccionar un objeto que concuerde con la condicional
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        private IEnumerable<Customer> GetCustomers()
        {

            return new List<Customer>
            {
                new Customer { Id=1, Name = "Jhonatan Rojas"},
                new Customer { Id=2, Name = "Renan Romero"}
            };
        }
    }
}