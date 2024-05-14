using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Models
{
    public class PlcInfo
    {
        public int Id { get; set; }
        public string PlcName { get; set; }
        public string PlcType { get; set; }
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
    }

    public abstract class DeviceData : IDeviceData
    {
        public byte SlaveId { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
    }

    public interface IDeviceData
    {
        byte SlaveId { get; }
        string IP { get; set; }
        int Port { get; set; }
    }

    public class Device01 : DeviceData
    {
        /* public  byte SlaveId { get; set; }
         public string IP { get; set; } 
         public int Port { get; set; } */
    }
}
