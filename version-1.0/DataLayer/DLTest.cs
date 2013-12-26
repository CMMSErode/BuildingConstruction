using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;

namespace DataLayer
{
    public class DLTest
    {
        public static int Add(ELTest objTest)
        {
            int c = 0;
            c = objTest.A * objTest.B;
            return c;
        }
    }
}
