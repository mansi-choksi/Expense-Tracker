using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ExpMvc.Models;

namespace ExpMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<cat> ctlist;
            HttpResponseMessage response1 = GlobalVariables.ExpApiClient.GetAsync("cats").Result;
            ctlist = response1.Content.ReadAsAsync<IEnumerable<cat>>().Result;

            var Categories = ctlist.ToList();
            if (Categories != null)
            {
                ViewBag.categories = Categories;
            }

            IEnumerable<totexp> totexplist;
            HttpResponseMessage response2 = GlobalVariables.ExpApiClient.GetAsync("cats").Result;
            totexplist = response2.Content.ReadAsAsync<IEnumerable<totexp>>().Result;
            var totalexpances = totexplist.ToList();
            if (totalexpances != null)
            {
                ViewBag.totalexpances = totalexpances;
            }

            IEnumerable<exp> explist;
            HttpResponseMessage response = GlobalVariables.ExpApiClient.GetAsync("exps").Result;
            explist = response.Content.ReadAsAsync<IEnumerable<exp>>().Result;

            var Expances = explist.ToList();
            if (Expances != null)
            {
                ViewBag.expances = Expances;
            }

            int kj = 0;
            foreach(var i in explist)
            {
                kj += ((int)i.amount);

            }
            ViewBag.kj = kj;
            return View();
        }


    }
}