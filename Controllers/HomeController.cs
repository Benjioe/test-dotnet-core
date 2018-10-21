using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using test_dotnet_core.Models;

namespace test_dotnet_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly string[] _listTrucCool;
        public HomeController(IConfiguration configuration) {
            var sectionCOnfiguration = configuration.GetSection("TrucCools");
            _listTrucCool = sectionCOnfiguration.Get<Dictionary<string, string>>().Keys.ToArray();
        }



        public IActionResult Index()
        {
            return View();
        }

        //https://forums.asp.net/t/1931780.aspx?Preventing+model+validation+on+first+time+load
        public IActionResult IndexError(IndexViewModel model)
        {
            return View("Index", model);
        }

        
        
        public IActionResult OneOfTrucCool(string name)
        {
            return View("TrucCool", model: name);
        }

        
        public ActionResult Classement([BindRequired] IndexViewModel model) {
            if(ModelState.IsValid)
                return View();
                
            return RedirectToAction("IndexError", model);
        }
       
        public IActionResult VerifiyIsTrucCool(string premierTrucCool, string secondTrucCool) {
            if (! string.IsNullOrEmpty(premierTrucCool) && !_listTrucCool.Contains(premierTrucCool))
            {
                return Json($"La valeur '{premierTrucCool}' n'est pas un truc cool.");
            }


            if (! string.IsNullOrEmpty(secondTrucCool) && !_listTrucCool.Contains(secondTrucCool))
            {
                return Json($"La valeur '{secondTrucCool}' n'est pas un truc cool.");
            }


            return Json(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
