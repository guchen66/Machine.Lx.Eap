using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Models
{
    public class DeviceInfo
    {
        public string Name { get; set; }
        public string YieId { get; set; }       //良率
        public int CT { get; set; }
        public int OKCount {  get; set; }
        public int NGCount {  get; set; }
        public DeviceInfo() { }
    }
}
