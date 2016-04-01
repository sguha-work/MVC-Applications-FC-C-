using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationDataBase.Models;
using FusionCharts.Charts;
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
                jsonString += "{\"label\": \"" + countryName + "\",\"value\": \"" + country.Population + "\"},";
            }
            jsonString = jsonString.Remove(jsonString.Length - 1);
            jsonString += "]";


            // preparing the chart
            String html = "";
            Chart sales = new Chart();

            // Setting chart id
            sales.SetChartParameter(Chart.ChartParameter.chartId, "myChart");

            // Setting chart type to Column 3D chart
            sales.SetChartParameter(Chart.ChartParameter.chartType, "column2d");

            // Setting chart width to 600px
            sales.SetChartParameter(Chart.ChartParameter.chartWidth, "600");

            // Setting chart height to 350px
            sales.SetChartParameter(Chart.ChartParameter.chartHeight, "350");

            // Setting chart data as JSON string
            sales.SetData("{\"chart\":{\"caption\":\"World Population\",\"xaxisname\":\"Country\",\"yaxisname\":\"Population\",\"showvalues\":\"1\",\"animation\":\"0\"},\"data\":"+jsonString+"}", Chart.DataFormat.json);


            html = sales.Render();

            ViewBag.displayHTML = html;
            return View();
        }

    }
}
