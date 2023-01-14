using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ExpMvc.Models;

namespace ExpMvc.Controllers
{
    public class catsController : Controller
    {
        // GET: cats
        public ActionResult Index()
        {
            IEnumerable<cat> ctlist;
            HttpResponseMessage response = GlobalVariables.ExpApiClient.GetAsync("cats").Result;
            ctlist = response.Content.ReadAsAsync<IEnumerable<cat>>().Result;
            return View(ctlist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new cat());
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.GetAsync("cats/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<cat>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(cat cat)
        {
            if (cat.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.PostAsJsonAsync("cats", cat).Result;
                TempData["SuccessMessage"] = " Category Inserted Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.ExpApiClient.PutAsJsonAsync("cats/" + cat.id, cat).Result;
                TempData["SuccessMessage"] = " Category Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.ExpApiClient.DeleteAsync("cats/" + id.ToString()).Result;
            TempData["SuccessMessage"] = " Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}