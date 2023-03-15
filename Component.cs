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
        public string componentBeforeImage1 { get; set; }
        public string componentBeforeImage2 { get; set; }
        public string componentBeforeImage3 { get; set; }
        public string componentAfterImage1 { get; set; }
        public string componentAfterImage2 { get; set; }
        public string componentAfterImage3 { get; set; }
        public string description { get; set; }

        public Component(string name, string componentBeforeImage1, string componentBeforeImage2, string componentBeforeImage3, string componentAfterImage1, string componentAfterImage2, string componentAfterImage3, string description)
        {
            this.name = name;
            this.componentBeforeImage1 = componentBeforeImage1;
            this.componentBeforeImage2 = componentBeforeImage2;
            this.componentBeforeImage3 = componentBeforeImage3;
            this.componentAfterImage1 = componentAfterImage1;
            this.componentAfterImage2 = componentAfterImage2;
            this.componentAfterImage3 = componentAfterImage3;
            this.description = description;
        }

        public Component()
        {
        }
    }
}
