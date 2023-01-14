using ExpMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExpMvc.Controllers
{
    public class totexpsController : Controller
    {
        // GET: totexps
        public ActionResult Index()
        {
            IEnumerable<totexp> totexplist;
            HttpResponseMessage response = GlobalVariables.ExpApiClient.GetAsync("totexps").Result;
            totexplist = response.Content.ReadAsAsync<IEnumerable<totexp>>().Result;
            return View(totexplist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new totexp());
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.GetAsync("totexps/" + id.ToString()).Result;
                TempData["SuccessMessage"] = " Total Expance Inserted Successfully";
                return View(response.Content.ReadAsAsync<totexp>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(totexp totalexp)
        {
            if (totalexp.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.PostAsJsonAsync("totexps", totalexp).Result;
                TempData["SuccessMessage"] = " Total Expance Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.PutAsJsonAsync("totexps/" + totalexp.id, totalexp).Result;
                TempData["SuccessMessage"] = " Total Expance Updated Successfully";
            }
            return RedirectToAction("Index");
        }
    }
}