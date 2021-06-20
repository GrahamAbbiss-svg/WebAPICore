using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.Models
{
    public class ControlInfo
    {
        public string ControlType { get; set; }
        public string ControlID { get; set; }
        public string ControlName { get; set; }
        public string ControlValue { get; set; }
        public string ControlLabel { get; set; }
        public bool IsChecked { get; set; }
    }
}

