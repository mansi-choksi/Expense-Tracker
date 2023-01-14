using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ExpMvc.Models;

namespace ExpMvc.Controllers
{
    public class expsController : Controller
    {
        // GET: exps
        public ActionResult Index()
        {
            IEnumerable<exp> explist;
            HttpResponseMessage response = GlobalVariables.ExpApiClient.GetAsync("exps").Result;
            explist = response.Content.ReadAsAsync<IEnumerable<exp>>().Result;
            return View(explist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            IEnumerable<cat> ctlist;
            HttpResponseMessage response1 = GlobalVariables.ExpApiClient.GetAsync("cats").Result;
            ctlist = response1.Content.ReadAsAsync<IEnumerable<cat>>().Result;

            var Categories = ctlist.ToList();
            if (Categories != null)
            {
                ViewBag.data = Categories;
            };
            if (id == 0)
                return View(new exp());
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.GetAsync("exps/" + id.ToString()).Result;
                TempData["SuccessMessage"] = " Expance Inserted Successfully";
                return View(response.Content.ReadAsAsync<exp>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(exp exp)
        {
            IEnumerable<cat> ctlist;
            HttpResponseMessage response1 = GlobalVariables.ExpApiClient.GetAsync("cats").Result;
            ctlist = response1.Content.ReadAsAsync<IEnumerable<cat>>().Result;

            var Categories = ctlist.ToList();
            if (Categories != null)
            {
                ViewBag.data = Categories;
            }

            if (exp.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.PostAsJsonAsync("exps", exp).Result;
                TempData["SuccessMessage"] = " Expance Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.PutAsJsonAsync("exps/" + exp.id, exp).Result;
                TempData["SuccessMessage"] = " Expance Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.ExpApiClient.DeleteAsync("exps/" + id.ToString()).Result;
            TempData["SuccessMessage"] = " Expance Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}