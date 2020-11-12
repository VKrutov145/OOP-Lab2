using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Lab2
{
    public class Submarine
    {
        public string subCountry = null;
        public string subType = null;
        public string subClass { get; set; } = null;
        public string subYear { get; set; } = null;
        public string ifSubNuclear { get; set; } = null;
        public string subLength { get; set; } = null;
        public Submarine() { }
        public Submarine(string[] data)
        {
            subCountry = data[0];
            subType = data[1];
            subClass = data[2];
            subYear = data[3];
            ifSubNuclear = data[4];
            subLength = data[5];
        }
        public bool Compare(Submarine obj)
        {
            if((this.subCountry == obj.subCountry) &&
               (this.subType == obj.subType) && 
               (this.subClass == obj.subClass) && 
               (this.subYear == obj.subYear) && 
               (this.ifSubNuclear == obj.ifSubNuclear) && 
               (this.subLength == obj.subLength))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}