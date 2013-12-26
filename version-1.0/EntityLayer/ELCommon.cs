using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
  public class ELCommon
    {
        public int ID { get; set; }      
        public int Creator { get; set; }
        public DateTime Created { get; set; }
        public bool? IsActive { get; set; }
    }
}
