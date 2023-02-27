using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tåg_project
{
    public class Component
    {
        public string name { get; set; }
        public List<string> images { get; set; }
        public string description { get; set; }

        public Component(string name, List<string> images, string description)
        {
            this.name = name;
            this.images = images;
            this.description = description;
        }
    }
}
