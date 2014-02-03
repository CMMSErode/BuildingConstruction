using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class ELEstimation:ELBasePage
    {       
        public string Site { get; set; }
        public string QualityType { get; set; }
        public int Units { get; set; }
        public string UnitType { get; set; }
        public int RatePerUnit { get; set; }
        public int TotalCost { get; set; }        
    }
}
