using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.Models
{
    public class HomeModel
    {
        public List<ControlInfo> ControlList { get; set; }

        public void PolulateControlList()
        {
            //You can fill this list from database. 
            // For example i have filled the list manually.
            ControlList = new List<ControlInfo>();
            ControlList.Add(new ControlInfo() { ControlType = "TextBox", ControlName = "tbox1", ControlID = "tbox1", ControlLabel = "Name", ControlValue = "Martin" });

            ControlList.Add(new ControlInfo() { ControlType = "CheckBox", ControlName = "cbox1", ControlID = "cbox1", ControlLabel = "Is Correct", ControlValue = "Yes", IsChecked = true });


        }
    }
}
