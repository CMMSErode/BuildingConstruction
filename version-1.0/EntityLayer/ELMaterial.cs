using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class ELMaterial
    {        
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Creator { get; set; }
        public DateTime Created { get; set; }
        public bool? IsActive { get; set; }

    }
}
