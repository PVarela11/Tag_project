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
        public string componentImg { get; set; }
        public string componentBeforeImg { get; set; }
        public string componentAfterImg { get; set; }
        public string description { get; set; }

        public Component(string name, string componentImg, string componentBeforeImg, string componentAfterImg, string description)
        {
            this.name = name;
            this.componentAfterImg = componentAfterImg;
            this.componentBeforeImg = componentBeforeImg;
            this.componentImg= componentImg;
            this.description = description;
        }

        public Component()
        {
        }
    }
}
