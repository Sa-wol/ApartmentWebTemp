using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentWebTemp.Controllers
{
    [Authorize(Roles = "Tenant")]
    public class ResidentPortalController : Controller
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
