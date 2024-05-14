using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Services.IServices
{
    public interface ICCDService
    {
         Task<bool> SendAll();
         Task<bool> ReceiveAll();
         Task<bool> SendData(int ccd,string str);
    }
}
