using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class BLTest
    {
        public static int Add(ELTest objTest)
        {
            return DLTest.Add(objTest);
        }
    }
}
