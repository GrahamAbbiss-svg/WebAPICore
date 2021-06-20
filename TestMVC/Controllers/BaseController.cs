using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestMVC.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new UserVm User
        {
            get { return HttpContext.User as UserVm; }
        }
    }
}