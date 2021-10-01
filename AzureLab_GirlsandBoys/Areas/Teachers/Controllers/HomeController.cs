using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureLab_GirlsandBoys.Areas.Teachers.Controllers
{
    //This Area tag is used to link the correct area
    [Area("Teachers")]
    public class HomeController : Controller
    {
        //with the are defined this code is used to claim the correct route for the view page.
        //It is going to be used by the default index to locate the correct view
        [Route("[area]/[controller]/{id?}")]
        public IActionResult Index()
        {
            ViewBag.Greeting = "For the Teachers";
            return View();
        }
    }
}
