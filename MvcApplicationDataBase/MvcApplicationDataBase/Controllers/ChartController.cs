using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationDataBase.Models;

namespace MvcApplicationDataBase.Controllers
{
    public class ChartController : Controller
    {
        //
        // GET: /Chart/
        private dynamic getDataFromModel() 
        {
            WorldPopulationEntities storeDB = new WorldPopulationEntities();
            return storeDB.WorldPopulations.ToList();
        }
        public ActionResult Index()
        {
            var dataFromDatabase = getDataFromModel();
            // preparing the json data for the chart
            String jsonString = "[";
            foreach (var country in dataFromDatabase)
            {
                String countryName = country.CountryName;
                jsonString += "{\"name\": \"" + countryName + "\",\"population\": \"" + country.Population + "\"},";
            }
            jsonString = jsonString.Remove(jsonString.Length - 1);
            jsonString += "]";

            return View();
        }

    }
}
