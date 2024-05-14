using Machine.Lx.Eap.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Globals
{
    public class GlobalCCD
    {
        public static bool CCD_ConnFlag = false;

        public static CCDManager CCDManager = new CCDManager();
    }
}
