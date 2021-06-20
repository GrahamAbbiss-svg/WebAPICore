using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APIRequestsCore.WebRequestInterface;
using BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMVC.Models;
using System.Data.SqlClient;
using TestMVC.HelperClass;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;
//using System.Web.Mvc;

namespace TestMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        const string sessionKey1 = "MatterID";
        private IMemoryCache _cache;
        private MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromSeconds(6000));
        public HomeController(IEmployeeService employeeService, IMemoryCache memoryCache)
        {
            _employeeService = employeeService;
            _cache = memoryCache;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(6000));

        }
        [HttpPost]
        public IActionResult JSonStudent(String node)
        {
            var model = JsonConvert.DeserializeObject<List<Students>>(node);
            return View();
        }

        [HttpGet]
        public IActionResult JSonPost(String node)
        {
            Object obj = new Object();
            obj = JsonConvert.DeserializeObject(node);
            ArrayList ids = new ArrayList();
            ids = (ArrayList)obj;
            return View();
        }

        [HttpGet]
        public IActionResult JQuery()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> City(int CityID)
        {
            List<City> cities = new List<City>();
            cities = await _employeeService.GetCityDescription(CityID).ConfigureAwait(false);
            ViewBag.Description = cities[0].Description;
            return PartialView("~/Views/Home/City.cshtml",cities);
        }
        [HttpGet]
        public async Task<IActionResult> AWSEmployee()
        {
            var employees = await _employeeService.Employees().ConfigureAwait(false);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            List<Employee> employees = new List<Employee>();
            employees = await _employeeService.GetEmployee().ConfigureAwait(false);
            return View("~/Views/Home/Employee.cshtml", employees);
        }
        [HttpGet]
        public IActionResult CaseNoteDetails(string Details)
        {
            CaseNotesVm casenote = new CaseNotesVm();
            casenote.CaseHeaderId = 1;
            return PartialView("~/Views/Home/_CaseNoteDetails.cshtml", casenote);
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return PartialView("~/Views/Home/Contacts.cshtml");
        }


        [HttpGet]
        public IActionResult Contacts()
        {
            List<Contacts> lstcontacts = new List<Contacts>();
            List<Contacts> lstfiltcontacts = new List<Contacts>();

            Contacts contacts1 = new Contacts();
            Contacts contacts2 = new Contacts();
            Contacts contacts3 = new Contacts();

            contacts1.Id = 22;
            contacts1.Name = "Reece";
            contacts1.MobileNumber = "098767654";

            contacts2.Id = 54;
            contacts2.Name = "Dave";
            contacts2.MobileNumber = "087676509";

            contacts3.Id = 72;
            contacts3.Name = "Dan";
            contacts3.MobileNumber = "0987656543";


            lstcontacts.Add(contacts1);
            lstcontacts.Add(contacts2);
            lstcontacts.Add(contacts3);

            foreach (Contacts contac in lstcontacts.Where(s => s.Name.StartsWith("D")).OrderBy(s => s.Name))
            {
                lstfiltcontacts.Add(contac);
            }

            IEnumerable<Contacts> contacs =
                from contact in lstcontacts
                where contact.Name.StartsWith("D")
                orderby contact.Name
                select contact;
            
            return Json(JsonConvert.SerializeObject(lstfiltcontacts));
        }
        [HttpGet]
        public async Task<IActionResult> Documents()
        {
            List<Document> documents = new List<Document>();
            documents = await _employeeService.GetDocuments().ConfigureAwait(false);
            return View("~/Views/Home/Documents.cshtml", documents);
        }
        [HttpGet]
        public ActionResult MyHtmlView()
        {
            //System.Threading.Thread.Sleep(25000);
            //HomeModel ModelObj = new HomeModel();
            //ModelObj.PolulateControlList();
            ////return Content("<html><body>Ahoy.</body></html>", "text/html");
            ////return PartialView("~/Views/Home/DynamicControls.cshtml", ModelObj);
            ////return Content("<html><body><table><tr><td>Name</td><td><input type=\"hidden\"</td></tr></table></body></html>", "text/html");
            //return Content("<html><body><table><tr><td>Name</td><td><input type=\"hidden\" name=\"ControlList[0].ControlID\" value=\"tbox1\" /><input type=\"hidden\" name=\"ControlList[0].ControlLabel\" value=\"Name\" /><input type=\"hidden\" name=\"ControlList[0].ControlName\" value=\"tbox1\" /><input type=\"hidden\" name=\"ControlList[0].ControlType\" value=\"TextBox\" /><input type=\"text\" name=\"ControlList[0].ControlValue\" id=\"tbox1\" value=\"Martin\" /></td></tr></table></body></html>", "text /html");
            return PartialView();
        }
        [HttpGet]
        public ActionResult GetMyHtmlView()
        {
            //HomeModel ModelObj = new HomeModel();
            //ModelObj.PolulateControlList();
            StringBuilder sb = new StringBuilder();
            //sb.Append("<table><tr><td>Name</td><td>");

            //foreach(TestMVC.Models.ControlInfo control in ModelObj.ControlList)
            //{
            //    sb.Append("< input type =");
            //    sb.Append("\"hidden\"");
            //    //sb.Append("\"\"");
            //    sb.Append("name =\"ControlList[0].ControlID\"" );
            //    sb.Append("value =\"tbox1\"");
            //    //sb.Append(control.ControlID);
            //    sb.Append("/>");
            //}

            //sb.Append("</td></tr></table>");
            sb.Append("<div><textarea cols=\"20\" id=\"Description\" name=\"Description\" rows=\"2\"></textarea></div><br />");
            sb.Append("<div><input id=\"StudentName\" name=\"StudentName\" type=\"text\" value=\"\" /></div><br />");
            sb.Append("<div><select class=\"form - control\" id=\"StudentGender\" name=\"StudentGender\"><option>Select Gender</option> <option>Male</option> <option>Female</option> </select></div><br />");
            sb.Append("<div><input id=\"Submit\" type=\"submit\" value=\"submit\" /></div>");
            //return Content("<div><textarea cols=\"20\" id=\"Description\" name=\"Description\" rows=\"2\"></textarea></div><br /><div><input id=\"StudentName\" name=\"StudentName\" type=\"text\" value=\"\" /></div><br /><div><select class=\"form - control\" id=\"StudentGender\" name=\"StudentGender\"><option>Select Gender</option> <option>Male</option> <option>Female</option> </select></div><br /><div><input id=\"Submit\" type=\"submit\" value=\"submit\" /></div>", "text /html");
            //return Content("<table><tr><td>Name</td><td><input type=\"hidden\" name=\"ControlList[0].ControlID\" value=\"tbox1\" /><input type=\"hidden\" name=\"ControlList[0].ControlLabel\" value=\"Name\" /><input type=\"hidden\" name=\"ControlList[0].ControlName\" value=\"tbox1\" /><input type=\"hidden\" name=\"ControlList[0].ControlType\" value=\"TextBox\" /><input type=\"text\" name=\"ControlList[0].ControlValue\" id=\"tbox1\" value=\"Martin\" /></td></tr></table>", "text /html");

            return Content(sb.ToString(), "text /html");
        }
        public ActionResult DropDownTest()
        {
            DropTest dt = new DropTest();
            dt.Id = "dt1";
            List<string> s = new List<string>();
            s.Add("test1");
            s.Add("test2");
            s.Add("test3");
            dt.ListData = s;
            return View(dt);
        }
        [HttpPost]
        public ActionResult MyHtmlView(IFormCollection collection)
        {
            string Description = Convert.ToString(collection["Description"]);
            string StudentName = Convert.ToString(collection["StudentName"]);
            string StudentGender = Convert.ToString(collection["StudentGender"]);
            return RedirectToAction("MyHtmlView", "Home");
            //return new EmptyResult();
            //return Content("<div><textarea cols=\"20\" id=\"Description\" name=\"Description\" rows=\"2\"></textarea></div><br /><div><input id=\"StudentName\" name=\"StudentName\" type=\"text\" value=\"\" /></div><br /><div><select class=\"form - control\" id=\"StudentGender\" name=\"StudentGender\"><option>Select Gender</option> <option>Male</option> <option>Female</option> </select></div><br /><div><input id=\"Submit\" type=\"submit\" value=\"submit\" /></div>", "text /html");
        }

        [HttpGet]
        public IActionResult CreateDropDown()
        {
            DateTime cacheEntry;
            CacheKeys.DropDownArray.Clear();
            //CacheKeys.DropDownArray.Add(0);
            // Look for cache key.
            if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now;
                
                // Set cache options.
                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //    // Keep in cache for this time, reset time if accessed.
                //    .SetSlidingExpiration(TimeSpan.FromSeconds(6000));

                // Save data in cache.
                _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
                _cache.Set(CacheKeys.DropDownArray, CacheKeys.DropDownArray,cacheEntryOptions);
                
            }
            DataSet ds = new DataSet();
            CreateUserVm uservm = new CreateUserVm();
            uservm.SelectedLabId = 1;
            ds=DataAccess.GetPrompts(0);

            SelectListItem  user = new SelectListItem();
            SelectListItem user1 = new SelectListItem();
            List<SelectListItem> uservms = new List<SelectListItem>();
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                user.Value = (int)dr.ItemArray[1];
                uservm.PromptLabel = "Prompt " + dr.ItemArray[1].ToString();
                user.Text = dr.ItemArray[2].ToString();
            }
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                user1.Value = (int)dr.ItemArray[1];
                user1.Text = dr.ItemArray[3].ToString();
            }
            
            uservms.Add(user);
            uservms.Add(user1);
            uservm.Labs = uservms;

            return View("~/Views/Home/CreateDropDown.cshtml", uservm);
        }

        [HttpPost]
        public IActionResult CreateDropDown(CreateUserVm uservm,IFormCollection collection)
        {
            ArrayList ddvalues;
            var cacheEntry = _cache.Get<DateTime?>(CacheKeys.Entry);
            ddvalues = _cache.Get<ArrayList>(CacheKeys.DropDownArray);
            string color1 = Convert.ToString(collection["DropDown"]);
            string color2 = Convert.ToString(collection["color2"]);
            string color3 = Convert.ToString(collection["color3"]);
            string color4 = Convert.ToString(collection["color4"]);
            _cache.Remove(CacheKeys.DropDownArray);
            CacheKeys.DropDownArray.Clear();
            return RedirectToAction("CreateDropDown", "Home");
           
        }

        [HttpGet]
        public IActionResult DynamicDropDown(string BookingTypeId)
        {
            var cacheEntry = _cache.Get<DateTime?>(CacheKeys.Entry);
            string[] values = BookingTypeId.Split(",");
            DataSet ds = new DataSet();
            CreateUserVm uservm = new CreateUserVm();
            uservm.SelectedLabId = 1;
            ViewBag.TypeId = BookingTypeId;

            if (CacheKeys.DropDownArray.Contains(values[0]))
            {
                return Content("0");
            }
            else
            {
                CacheKeys.DropDownArray.Add(values[0]);
                _cache.Set(CacheKeys.DropDownArray, CacheKeys.DropDownArray, cacheEntryOptions);
            }

            ds = DataAccess.GetPrompts(Int16.Parse(values[0]));

            SelectListItem user = new SelectListItem();
            SelectListItem user1 = new SelectListItem();
            List<SelectListItem> uservms = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                uservm.BookingTypeId = dr.ItemArray[1].ToString();
                uservm.DivId= "DynamicDiv" + dr.ItemArray[1].ToString();
                uservm.PromptLabel = "Prompt " + dr.ItemArray[1].ToString();
                user.Value = (int)dr.ItemArray[1];
                user.Text = dr.ItemArray[2].ToString();
                uservm.BookingValue = user.Text;

            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                user1.Value = (int)dr.ItemArray[1];
                user1.Text = dr.ItemArray[3].ToString();
            }

            uservms.Add(user);
            uservms.Add(user1);
            uservm.Labs = uservms;
            return PartialView("~/Views/Home/DynamicDropDown.cshtml", uservm);
        }

        public ActionResult DynamicControls()
        {
            HomeModel ModelObj = new HomeModel();
            ModelObj.PolulateControlList();
            return View(ModelObj);
        }

        [HttpPost]
        public ActionResult DynamicControls(HomeModel ModelObj)
        {
            // Your logic..........
            return View(ModelObj);
        }
        public IActionResult DynamicDropDown1(string BookingTypeId)
        {
            DataSet ds = new DataSet();
            string[] values = BookingTypeId.Split(",");
            CreateUserVm uservm = new CreateUserVm();
            uservm.SelectedLabId = 1;
            ViewBag.TypeId = BookingTypeId;
     
            
            if (CacheKeys.DropDownArray.Contains(values[0]))
            {
                return Content("0");
            }
            else
            {
                CacheKeys.DropDownArray.Add(values[0]);
                 _cache.Set(CacheKeys.DropDownArray, CacheKeys.DropDownArray, cacheEntryOptions);
            }
          
            ds = DataAccess.GetPrompts(Int16.Parse(values[0]));

            SelectListItem user = new SelectListItem();
            SelectListItem user1 = new SelectListItem();
            List<SelectListItem> uservms = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                uservm.BookingTypeId = dr.ItemArray[1].ToString();
                uservm.DivId = "DynamicDiv" + dr.ItemArray[1].ToString();
                uservm.PromptLabel = "Prompt " + dr.ItemArray[1].ToString();
                user.Value = (int)dr.ItemArray[1];
                user.Text = dr.ItemArray[2].ToString();
                uservm.BookingValue = user.Text;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                user1.Value = (int)dr.ItemArray[1];
                user1.Text = dr.ItemArray[3].ToString();
            }

            uservms.Add(user);
            uservms.Add(user1);
            uservm.Labs = uservms;

            if (uservm.BookingValue == null)
            {
               return Content(""); 
            }
            else
            {
                return PartialView("~/Views/Home/DynamicDropDown.cshtml", uservm);
            }
            
        }

        public IActionResult UpdateCache(int Id)
        {
            int i;
            Id--;
            
            for (i = Id; i < 5; i++)
            {
                CacheKeys.DropDownArray.Remove(i.ToString());
            }
           
            return new EmptyResult();
           
        }

        [HttpGet]
        public IActionResult Slider()
        {
            string id=User.LoginID;
            Student stud = new Student();
            return View("~/Views/Home/Slider.cshtml", stud);
        }

        [HttpGet]
        public IActionResult Angular()
        {
            return View();
        }

        [HttpGet]
       
        [HttpGet]
        public IActionResult AngularTest()
        {
            //Student stud = new Student();
            //return PartialView("~/Views/Home/Slider.cshtml", stud);
            return Content("Hi there!");
        }

        [HttpPost]
        public ActionResult Slider(IFormCollection collection)
        {
            string sliderid = Convert.ToString(collection["SliderHider"]);
            string dropdownid = Convert.ToString(collection["DropDownHider"]);
            return new EmptyResult();
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
                return Json(new { success = false });
            }
            
        }

        [HttpGet]
        public ActionResult Download(string id)
        {
            var documentByte = new byte[] { };
            CaseFileBo caseFileBo = new CaseFileBo();

            caseFileBo = _employeeService.GetFile().Result;
            
            var fileName = string.Empty;

           
                if (caseFileBo.FileData != null)
                {
                    documentByte = caseFileBo.FileData;
                    fileName = caseFileBo.FileName;
                }
            

            return File(documentByte, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }

        public ActionResult HiddenTest()
        {
            UserModel obj = new UserModel();
            obj.UserId = 1;
            obj.UserName = "Orange";
            return View(obj);
        }

        [HttpPost]
        public ActionResult HiddenTest(IFormCollection collection, UserModel um)
        {
            string productid = Convert.ToString(collection["BasicHiddenName"]);
            ViewBag.basicname = collection["BasicHiddenName"];
            ViewBag.id = um.UserId;
            ViewBag.name = um.UserName;
            return View(um);
        }
        [HttpGet]
        public IActionResult AutoFill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JQueryDate(IFormCollection collection)
        {
            string productid = Convert.ToString(collection["EnterDate"]);
            return RedirectToAction("JQuery", "Home");
        }

        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SliderQI()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles()  
       {
            string fName="";
            Result<bool> files;
            List<CaseFileBo> caseFileBo = new List<CaseFileBo>();
            CaseFileBo caseFile = new CaseFileBo();
            var filePath = Path.GetTempFileName();
            foreach (var formFile in Request.Form.Files)
            {
                if (formFile.Length > 0)
                {
                    using (var inputStream = new FileStream(filePath, FileMode.Create))
                    {
                        // read file to stream
                        await formFile.CopyToAsync(inputStream);
                        // stream to byte array
                        byte[] array = new byte[inputStream.Length];
                        inputStream.Seek(0, SeekOrigin.Begin);
                        inputStream.Read(array, 0, array.Length);
                        // get file name
                        fName = formFile.FileName;
                        caseFile.FileData = array;
                        caseFile.FileName = fName;
                        caseFile.FinalFileName = fName;
                        caseFileBo.Add(caseFile);
                        files = await _employeeService.AddFiles(caseFileBo).ConfigureAwait(false);
                    }
                }
            }
            return Ok(fName);
        }  
        [HttpPost]
        public ActionResult UploadFiles1(List<IFormFile> fileData)
        {
            long size = fileData.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in fileData)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = fileData.Count, size, filePath });
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dogs()
        {
            var model = new Dogs();
            List<SuperDogs> dogGrid = model.GetHardCodedValues();
            return View(dogGrid);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
