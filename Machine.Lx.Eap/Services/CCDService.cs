using Machine.Lx.Eap.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Services
{
    public class CCDService : ICCDService
    {
        public Task<bool> ReceiveAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendData(int ccd, string str)
        {
            throw new NotImplementedException();
        }
    }
}
