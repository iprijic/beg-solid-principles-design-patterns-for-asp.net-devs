﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;



namespace Facade.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




    }
}
