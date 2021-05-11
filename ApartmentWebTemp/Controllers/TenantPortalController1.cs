using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentWebTemp.Controllers
{
    public class TenantPortalController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Maintenance()
        {
            return View();
        }
    }
}
