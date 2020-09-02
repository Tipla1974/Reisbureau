using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reisbureau.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;

namespace Reisbureau.Controllers
{
    public class HomeController : Controller
    {

        string Bezoeker;
        public IActionResult Index()
        {
            if (Request.Cookies["lastvisit"] != null) 
            {
                if (Request.Cookies["naamBezoeker"] != null)
                {
                    Bezoeker = Request.Cookies["naamBezoeker"];
                    ViewBag.Bezoeker = $"Welkom terug {Bezoeker}";
                    return View();
                }
                else
                {

                    Bezoeker = "";
                    ViewBag.Bezoeker = "";
                    return RedirectToAction("IngaveData");
                }
                


               
            }
            else
            {
                string laatsteBezoek = DateTime.Now.ToString(); 
                CookieOptions option = new CookieOptions(); 
                option.Expires = DateTime.Now.AddDays(365);  
                Response.Cookies.Append("lastvisit", laatsteBezoek, option);
                return RedirectToAction("IngaveData");
            }
                
        }
        public IActionResult IngaveData()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OpslaanData(BezoekerViewModel bezoekerViewModel)
        {
            if (this.ModelState.IsValid)
            {
                string bezoeker = bezoekerViewModel.Voornaam;
                CookieOptions optionNaam = new CookieOptions();
                Response.Cookies.Append("naamBezoeker", bezoeker, optionNaam);
                optionNaam.Expires = DateTime.Now.AddDays(365);
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("Ingavedata", bezoekerViewModel);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IngaveBestemming(BestemmingViewData bestemmingViewData)
        {
            var dataBestemming = HttpContext.Session.GetString("Bestemminglijst");
            List<string> myList = new List<string>();
            if (dataBestemming != null)
            {
                myList = JsonConvert.DeserializeObject<List<string>>(dataBestemming);

            }
            myList.Add(bestemmingViewData.Bestemming);
            var geserializeerdeList = JsonConvert.SerializeObject(myList);
            HttpContext.Session.SetString("Bestemminglijst", geserializeerdeList);
            return RedirectToAction("index");
        }
        
        public IActionResult Delete(string Plaats)
        {
            
            var dataBestemming = HttpContext.Session.GetString("Bestemminglijst");
            List<string> myList = new List<string>();
            myList = JsonConvert.DeserializeObject<List<string>>(dataBestemming);
            myList.Remove(Plaats);
            var geserializeerdeList = JsonConvert.SerializeObject(myList);
            HttpContext.Session.SetString("Bestemminglijst", geserializeerdeList);
            return RedirectToAction("index");
        }

    public IActionResult Verstuur()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("lastvisit");
            return RedirectToAction("index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
