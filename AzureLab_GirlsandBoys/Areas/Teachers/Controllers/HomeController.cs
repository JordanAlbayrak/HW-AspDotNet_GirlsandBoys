using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureLab_GirlsandBoys.Models.Task;

namespace AzureLab_GirlsandBoys.Areas.Teachers.Controllers
{
    //This Area tag is used to link the correct area
    [Area("Teachers")]
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;

        //with the are defined this code is used to claim the correct route for the view page.
        //It is going to be used by the default index to locate the correct view
        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [Route("[area]/[controller]/{id?}")]
        public IActionResult Index()
        {
            ViewBag.Greeting = "For the Teachers";
            var tasks = _taskService.GetTasks();
            return View(tasks);
        }
    }
}
