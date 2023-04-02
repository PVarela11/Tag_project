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
        public string componentBeforeFrontImage1 { get; set; }
        public string componentBeforeFrontImage2 { get; set; }
        public string componentBeforeFrontImage3 { get; set; }
        public string componentBeforeBackImage1 { get; set; }
        public string componentBeforeBackImage2 { get; set; }
        public string componentBeforeBackImage3 { get; set; }
        public string componentAfterFrontImage1 { get; set; }
        public string componentAfterFrontImage2 { get; set; }
        public string componentAfterFrontImage3 { get; set; }
        public string componentAfterBackImage1 { get; set; }
        public string componentAfterBackImage2 { get; set; }
        public string componentAfterBackImage3 { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string state { get; set; }
        public string location { get; set; }

        public Component(string name, 
            string componentBeforeFrontImage1, string componentBeforeFrontImage2, string componentBeforeFrontImage3,
            string componentBeforeBackImage1, string componentBeforeBackImage2, string componentBeforeBackImage3,
            string componentAfterFrontImage1, string componentAfterFrontImage2, string componentAfterFrontImage3,
            string componentAfterBackImage1, string componentAfterBackImage2, string componentAfterBackImage3,
            string description)
        {
            this.name = name;
            this.componentBeforeFrontImage1 = componentBeforeFrontImage1;
            this.componentBeforeFrontImage2 = componentBeforeFrontImage2;
            this.componentBeforeFrontImage3 = componentBeforeFrontImage3;
            this.componentBeforeBackImage1 = componentBeforeBackImage1;
            this.componentBeforeBackImage2 = componentBeforeBackImage2;
            this.componentBeforeBackImage3 = componentBeforeBackImage3;
            this.componentAfterFrontImage1 = componentAfterFrontImage1;
            this.componentAfterFrontImage2 = componentAfterFrontImage2;
            this.componentAfterFrontImage3 = componentAfterFrontImage3;
            this.componentAfterBackImage1 = componentAfterBackImage1;
            this.componentAfterBackImage2 = componentAfterBackImage2;
            this.componentAfterBackImage3 = componentAfterBackImage3;
            this.description = description;
        }

        public Component()
        {
        }
    }
}
