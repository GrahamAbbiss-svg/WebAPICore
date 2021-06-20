using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper;
using BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCallAPICore.Models;
using WebAPI.Models;
using Civica.Core.BO;
using Microsoft.AspNetCore.Authorization;
using APIRequestsCore.WebRequestInterface;


namespace MVCCallAPICore.Controllers
{
    public class KendoController : Controller
    {
        private readonly IEmployeeService _employeeService;
        List<LoadData> treeData = new List<LoadData>();
        public KendoController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }
        public async Task<IActionResult> Employee()
        {
            List<Employee> employees=new List<Employee>();
            //employees = await _employeeService.GetEmployee().ConfigureAwait(false);
            return PartialView("~/Views/Kendo/Events.cshtml", employees);
        }

        public IActionResult Slider()
        {
            return View();
        }
        public JsonResult GetEmployees()
        {
            //List<Employee> employees;
            //employees = _employeeService.GetEmployee().Result;

            //return Json(employees);

            treeData.Add(new LoadData
            {
                Id = 1,
                Parent = 0,
                Text = "Item 1",
                Expanded = true,
                NodeProperty = new Dictionary<string, string>() {
                    { "class", "text-blue" },
                    { "value", "Item 1" }
                    }
            });
            treeData.Add(new LoadData
            {
                Id = 2,
                Parent = 0,
                Text = "Item 2",
                LinkProperty = new Dictionary<string, string>() {
                    { "class", "text-underline" },
                    { "href", "http://www.syncfusion.com" },
                    { "target", "_blank"}
                    }
            });
            treeData.Add(new LoadData
            {
                Id = 3,
                Parent = 0,
                Text = "Item 3",
                Selected = true,
                SpriteImage = "mailicon sprite-calendar"
            });
            treeData.Add(new LoadData
            {
                Id = 4,
                Parent = 0,
                Text = "Item 4",
                NodeChecked = true,
                ImageProperty = new Dictionary<string, string>() {
                    { "width", "20px" },
                    { "height", "20px" }
                    },
                ImageURL = "http://cdn.syncfusion.com/13.3.0.7/js/web/flat-azure/images/ajax-loader.gif"
            });
            treeData.Add(new LoadData
            {
                Id = 5,
                Parent = 1,
                Text = "Item 1.1"
            });
            treeData.Add(new LoadData
            {
                Id = 6,
                Parent = 1,
                Text = "Item 1.2"
            });
            treeData.Add(new LoadData
            {
                Id = 7,
                Parent = 1,
                Text = "Item 1.3"
            });
            treeData.Add(new LoadData
            {
                Id = 8,
                Parent = 3,
                Text = "Item 3.1"
            });
            treeData.Add(new LoadData
            {
                Id = 9,
                Parent = 3,
                Text = "Item 3.2"
            });
            treeData.Add(new LoadData
            {
                Id = 10,
                Parent = 5,
                Text = "Item 1.1.1"
            });
            //ViewBag.datasource = treeData;
            //return View();
            //return Json(treeData, JsonRequestBehavior.AllowGet);
            return Json(treeData);
        }
        public ActionResult TreeView()
        {
            List<Employee> employees = new List<Employee>();
            //employees = await _employeeService.GetEmployee().ConfigureAwait(false);
            return PartialView("~/Views/Kendo/Grid.cshtml", employees);

           
        }
    }
}