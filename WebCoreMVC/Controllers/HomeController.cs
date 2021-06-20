using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APIRequestsCore.WebRequestInterface;
using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebCoreMVC.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly IEmployeeService _employeeService;
        //private readonly IMapper _mapper;
     
        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
         
            //_mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetCityDescription()
        {
            List<City> cities = new List<City>();
            cities = await _employeeService.GetCityDescription(1).ConfigureAwait(false);
            return View("~/Views/Home/City.cshtml");
        }


        [HttpGet]
        public IActionResult CaseNoteDetails()
        {
            CaseNotesVm casenote = new CaseNotesVm();
            return View("~/Views/Home/_CaseNoteDetails.cshtml", casenote);
        }

        [HttpPost]
        public IActionResult CaseNoteDetails(CaseNotesVm caseNotesVM)
        {
            if (ModelState.IsValid)
            {
                return Json(new { success = true });
            }
            else
            {
                ModelState.AddModelError("Incorrect Details", "Incorrect Details");
            }
            return Json(new { success = false });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
