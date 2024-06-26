﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Repository.Core;


namespace Repository.Controllers
{
    public class HomeController : Controller
    {
        // Uncomment the following code for DI

        //private ICustomerRepository repository;

        //public HomeController(ICustomerRepository repository)
        //{
        //    this.repository = repository;
        //}

        //public IActionResult Index()
        //{
        //    List<Customer> customers = repository.SelectAll();
        //    ViewBag.Customers = from c in customers
        //                        select new SelectListItem()
        //                        {
        //                            Text = c.CustomerID,
        //                            Value = c.CustomerID
        //                        };
        //    return View();
        //}


        public IActionResult Index()
        {
            using (CustomerRepository repository = new CustomerRepository())
            {
                List<Customer> customers = repository.SelectAll();
                ViewBag.Customers = from c in customers
                                    select new SelectListItem()
                                    {
                                        Text = c.CustomerID,
                                        Value = c.CustomerID
                                    };
                return View();
            }
        }

        [HttpPost]
        public IActionResult SelectByID(string customerid)
        {
            using (CustomerRepository repository = new CustomerRepository())
            {
                Customer data = repository.SelectByID(customerid);
                List<Customer> customers = repository.SelectAll();
                ViewBag.Customers = from c in customers
                                    select new SelectListItem()
                                    {
                                        Text = c.CustomerID,
                                        Value = c.CustomerID
                                    };
                return View("Index", data);
            }
        }

        [HttpPost]
        public IActionResult Update(Customer obj)
        {
            using (CustomerRepository repository = new CustomerRepository())
            {
                repository.Update(obj);
                repository.Save();
                List<Customer> customers = repository.SelectAll();
                ViewBag.Customers = from c in customers
                                    select new SelectListItem()
                                    {
                                        Text = c.CustomerID,
                                        Value = c.CustomerID
                                    };
                ViewBag.Message = "Customer modified successfully!";
                return View("Index", obj);
            }
        }
    }
}
