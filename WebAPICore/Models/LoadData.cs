using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCallAPICore.Models
{
    public class LoadData
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public string Text { get; set; }
        public string SpriteImage { get; set; }
        public string ImageURL { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public bool NodeChecked { get; set; }
        public object NodeProperty { get; set; }
        public object LinkProperty { get; set; }
        public object ImageProperty { get; set; }
    }
}
