using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    public class CoreWebController : Controller
    {
       
        public IActionResult Index()
        {
            return View("CoreWeb");
        }

    }
}