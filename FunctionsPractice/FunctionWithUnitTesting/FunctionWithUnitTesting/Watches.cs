using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionWithUnitTesting
{
    public class Watches
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CaseType { get; set; }
        public string Bezel { get; set; }
        public string Dial { get; set; }
        public string CaseFinish { get; set; }
        public string Jewels { get; set; }

        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(Watches))
            {
                return false;
            }
            //Typecasting obj as CountryresponsType
            Watches compair = (Watches)obj;
            //this.CountryIdthis.CountryId 'this' keyword is optional this refer to current object
            return this.Model == compair.Model && this.Manufacturer == compair.Manufacturer && this.CaseType == compair.CaseType && this.Bezel == compair.Bezel && this.Dial == compair.Dial && this.CaseFinish == compair.CaseFinish && this.Jewels == compair.Jewels;

        }

    }
}
