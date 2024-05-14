using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Devices.PLC
{
    public class PlcData
    {
        public static PlcCommonRegion CommonRegion=new PlcCommonRegion();
        public static PlcEventRegion EventRegion=new PlcEventRegion();
    }

    /// <summary>
    /// PLC公共区域数据
    /// </summary>
    public class PlcCommonRegion
    {
        public string Count { get; set; }     //总数
        public string OK {  get; set; }       //OK品
        public string NG {  get; set; }      //NG品
        public string YieId {  get; set; }   //良率
    }

    /// <summary>
    /// PLC触发事件传递的数据
    /// </summary>
    public class PlcEventRegion
    {

    }


    public class PcData
    {
        public static PcCommonRegion CommonRegion = new PcCommonRegion();
        public static PcEventRegion EventRegion = new PcEventRegion();
    }

    /// <summary>
    /// 上位机公共区数据
    /// </summary>
    public class PcCommonRegion
    {

    }

    /// <summary>
    /// 上位机触发事件传递给PLC的数据
    /// </summary>
    public class PcEventRegion
    {

    }
}
