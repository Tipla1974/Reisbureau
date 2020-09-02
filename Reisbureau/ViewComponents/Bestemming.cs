using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Reisbureau.ViewComponents
{
    public class Bestemming :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var dataBestemming = HttpContext.Session.GetString("Bestemminglijst");
            List<string> myList = new List<string>();
            if (dataBestemming != null) 
            {
                myList = JsonConvert.DeserializeObject<List<string>>(dataBestemming);
                
            }

            return View((object)myList);
            
        }
    }
}
