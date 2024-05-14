using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Services.IServices
{
    public interface IMesService
    {
        Task<bool> UploadDataToMesAsync(UpLoadData data);
    }

    public class UpLoadData
    {

    }
}
