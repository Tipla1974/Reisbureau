using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reisbureau.Models;
using Microsoft.AspNetCore.Http;

namespace Reisbureau.Controllers
{
    public class BestemmingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult OpslaanData(BezoekerViewModel bezoekerViewModel)
        {
            if (this.ModelState.IsValid)
            {
                string bezoeker = bezoekerViewModel.Voornaam;
                CookieOptions optionNaam = new CookieOptions();
                Response.Cookies.Append("naamBezoeker", bezoeker, optionNaam);
                optionNaam.Expires = DateTime.Now.AddDays(365);
                return RedirectToAction("index", "Home");
            }
            else
            {
                return View("index", bezoekerViewModel);
            }

        }
    }
}
