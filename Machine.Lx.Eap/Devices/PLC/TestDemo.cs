using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Devices.PLC
{
    public class TestDemo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public byte StartAddress { get; set; }
        public byte EndAddress { get; set; }
    }


    public class ExcelTest
    {
       // [ExcelColumnName(ExcelColumnName="", Aliases=new string)]
        public int Id { get; set; }
    }
}
