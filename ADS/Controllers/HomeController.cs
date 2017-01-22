using ADS.Models;
using ADS.Rule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public void SetData()
        {
            string json = string.Empty;
            bool hasFile = System.IO.File.Exists("D:\\temp\\ads.txt");
            if (!hasFile)
            {
                string url = "http://auction-api-cn.worldofwarcraft.com/auction-data/158d5fd0cb871eaf015187f459a82833/auctions.json";
                //string url = "http://mofxu.cn/home/getdata";
                json = HttpClient.Get(url);
                System.IO.File.WriteAllText("D:\\temp\\ads.txt", json);
            }
            else
            {
                json = System.IO.File.ReadAllText("D:\\temp\\ads.txt");
            }
            DataModel model = JsonConvert.DeserializeObject<DataModel>(json);
            using (ADSContext context = new ADSContext())
            {
                context.DataModels.Add(model);
                context.SaveChanges();
            }
        }

        public string GetData()
        {
            string url = "http://auction-api-cn.worldofwarcraft.com/auction-data/158d5fd0cb871eaf015187f459a82833/auctions.json";
            return HttpClient.Get(url);
        }
    }
}
