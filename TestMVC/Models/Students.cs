using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Students
    {
    [JsonProperty("firstName")]
    public string firstName { get; set; }
    [JsonProperty("middleInitial")]
    public string middleInitial { get; set; }
    [JsonProperty("lastName")]
    public string lastName { get; set; }
    [JsonProperty("fullName")]
    public string fullName { get; set; }
    
}

