using MiniExcelLibs;
using Machine.Lx.Eap.Helpers;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Machine.Lx.Eap.Models;

namespace Machine.Lx.Eap.Devices.PLC
{
    public class PlcProvider
    {
        private NameValueCollection _values;

        // 修改构造函数，使其不接受任何参数
        public PlcProvider()
        {
        }

        // 链式调用：ReadIniAllSection 方法现在返回 PlcProvider 实例
        public PlcProvider ReadIniAllSection(string section)
        {
            string iniFilePath = DirEx.CurrentDir() + "Config\\Setting.ini";
            IniFile ini = new IniFile(iniFilePath);
            _values = ini.GetSectionValues(section);
            return this; // 返回当前实例
        }

        // 链式调用：GetKey 方法现在返回 string 类型
        public string GetKey(string key)
        {
            if (_values != null && _values.AllKeys.Contains(key))
            {
                return _values[key]; // 返回找到的键对应的值
            }
            return null; // 如果键不存在，返回null
        }

        public void WriteValue(string key,string value)
        {
            string iniFilePath = DirEx.CurrentDir() + "Config\\Setting.ini";
            IniFile ini = new IniFile(iniFilePath);
            ini.Write("PlcInfo2", key, value);
            ini.UpdateFile();
        }

        public async Task GetPlcDataByLocalExcel()
        {
            await Task.Delay(1000);
            string filePath = "Devices\\PLC\\Modbus.xlsx";
            var path = DirectoryHelper.SelectDirectoryByName(filePath);
            var models = MiniExcel.Query<TestDemo>(path).ToList();
            var ct=models.Where(x=>x.Name=="温度").First().Value;
        }

        /// <summary>
        /// 将PLC传递的数据写入本地Excel
        /// </summary>
        public void WriteToExcel(List<PlcEventRegion> plcData)
        {
           
            // 指定要写入的sheet名，如果不存在则会自动创建
            var sheetName = "PLC_Data";

            // 将DataTable转换为IEnumerable<dynamic>，以便MiniExcel处理
          //  var data = plcData.AsEnumerable().Select(row => row.ItemArray.ToExpandoObject());

            // 写入Excel文件，这里假设你的Excel文件名为"plc_data.xlsx"
            var filePath = "plc_data.xlsx";

            // 检查文件是否存在，如果存在则删除，用AppendRow追加模式写入
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // 准备写入Excel的配置


            // 写入数据到Excel，AppendRow模式会在现有数据后面追加新行
            //    MiniExcel.SaveAs(filePath, data, options);
            ExcelHelper.WriteData3();
        }

        public void Workflows(string name)
        {
            Dictionary<string, Func<string>> dicts = new Dictionary<string, Func<string>>();
            dicts.Add("工位1", () => Event1()); ;

            if (dicts.TryGetValue(name, out var handler))
            {
                handler.Invoke();
            }
            else
            {
                dicts["未知工位"].Invoke();
            }
        }

        private string Event1()
        {
            return default(string);
        }
    }
    public class Software_Fixed
    {
        public const int NormalParItemNum = 100;                                             //普通参数数量

        public static bool[] np_HandyChk = new bool[NormalParItemNum + 1];                   //手动勾选项内容
        public static decimal[] np_HandyTbx_N = new decimal[NormalParItemNum + 1];           //手动文本项内容（数值型）
        public static string[] np_HandyTbx_S = new string[NormalParItemNum + 1];             //手动文本框内容（字符串型）
        public static bool[] np_BaseChk = new bool[NormalParItemNum + 1];                    //基础勾选项内容  
        public static decimal[] np_BaseTbx_N = new decimal[NormalParItemNum + 1];            //基础文本项内容（数值型）
        public static string[] np_BaseTbx_S = new string[NormalParItemNum + 1];              //基础文本框内容（字符串型）


        public static string[] np_HandyChk_Name = new string[NormalParItemNum + 1];          //手动勾选项名称
        public static string[] np_HandyTbx_N_Name = new string[NormalParItemNum + 1];        //手动文本项名称（数值型）
        public static string[] np_HandyTbx_S_Name = new string[NormalParItemNum + 1];        //手动文本框名称（字符串型）
        public static string[] np_BaseChk_Name = new string[NormalParItemNum + 1];           //基础勾选项名称
        public static string[] np_BaseTbx_N_Name = new string[NormalParItemNum + 1];         //基础文本项名称（数值型）
        public static string[] np_BaseTbx_S_Name = new string[NormalParItemNum + 1];         //基础文本框名称（字符串型）
    }

    public enum e_BaseTbx_N
    {
        ScrewTotalCount = 1,            //1.电批使用次数上限值
        RealMomentSampleTime = 2,       //2.实时显示电批扭矩采样间隔时间(ms)
        MachineNO = 3,                  //3.机台号
        Nozzle1Sta1OffsetX = 4,         //4.吸嘴1工位1补偿X
        Nozzle1Sta1OffsetY = 5,         //5.吸嘴1工位1补偿Y
        Nozzle1Sta1OffsetR = 6,         //6.吸嘴1工位1补偿R
        Nozzle1Sta2OffsetX = 7,         //7.吸嘴1工位2补偿X
        Nozzle1Sta2OffsetY = 8,         //8.吸嘴1工位2补偿Y
        Nozzle1Sta2OffsetR = 9,         //9.吸嘴1工位2补偿R
        Nozzle2Sta1OffsetX = 10,        //10.吸嘴2工位1补偿X
        Nozzle2Sta1OffsetY = 11,        //11.吸嘴2工位1补偿Y
        Nozzle2Sta1OffsetR = 12,        //12.吸嘴2工位1补偿R
        Nozzle2Sta2OffsetX = 13,        //13.吸嘴2工位2补偿X
        Nozzle2Sta2OffsetY = 14,        //14.吸嘴2工位2补偿Y
        Nozzle2Sta2OffsetR = 15,        //15.吸嘴2工位2补偿R

        XCalApart = 16,                 //16.X校正步距
        YCalApart = 17,                 //17.X校正步距
        LXIdealAngle = 18,              //18.左X理想角度
        LYIdealAngle = 19,              //19.左Y理想角度
        RXIdealAngle = 20,              //20.右X理想角度
        RYIdealAngle = 21,              //21.右Y理想角度

        LXAssembleOffset = 22,              //22.左X贴装补偿
        LYAssembleOffset = 23,              //23.左Y贴装补偿
        RXAssembleOffset = 24,              //24.右X贴装补偿
        RYAssembleOffset = 25,              //25.右Y贴装补偿
        LXIdealCoord = 26,                  //26.左X理想坐标
        LYIdealCoord = 27,                  //27.左Y理想坐标
        RXIdealCoord = 28,                  //28.右X理想坐标
        RYIdealCoord = 29,                  //29.右Y理想坐标
        LXFixedOffset = 30,                 //30.左X固定偏差
        LYFixedOffset = 31,                 //31.左Y固定偏差
        RXFixedOffset = 32,                 //32.右X固定偏差
        RYFixedOffset = 33,                 //33.右Y固定偏差
        LXAngleOffset = 34,                 //34.左载具角度补偿
        RXAngleOffset = 35,                 //35.右载具角度补偿
        RotateAngelLimit = 36,              //36.多次旋转角度界限
        standby37 = 37,                 //37.Standby
        standby38 = 38,                 //38.Standby
        standby39 = 39,                 //39.Standby
        standby40 = 40,                 //40.Standby

        standby41 = 41,                 //41.Standby
        standby42 = 42,                 //42.Standby
        standby43 = 43,                 //43.Standby
        standby44 = 44,                 //44.Standby
        standby45 = 45,                 //45.Standby
        standby46 = 46,                 //46.Standby
        standby47 = 47,                 //47.Standby
        standby48 = 48,                 //48.Standby
        standby49 = 49,                 //49.Standby
        standby50 = 50,                 //50.Standby

        standby51 = 51,                 //51.Standby
        standby52 = 52,                 //52.Standby
        standby53 = 53,                 //53.Standby
        standby54 = 54,                 //54.Standby
        standby55 = 55,                 //55.Standby
        standby56 = 56,                 //56.Standby
        standby57 = 57,                 //57.Standby
        standby58 = 58,                 //58.Standby
        standby59 = 59,                 //59.Standby
        standby60 = 60,                 //60.Standby

        standby61 = 61,                 //61.Standby
        standby62 = 62,                 //62.Standby
        standby63 = 63,                 //63.Standby
        standby64 = 64,                 //64.Standby
        standby65 = 65,                 //65.Standby
        standby66 = 66,                 //66.Standby
        standby67 = 67,                 //67.Standby
        standby68 = 68,                 //68.Standby
        standby69 = 69,                 //69.Standby
        standby70 = 70,                 //70.Standby

        standby71 = 71,                 //71.Standby
        standby72 = 72,                 //72.Standby
        standby73 = 73,                 //73.Standby
        standby74 = 74,                 //74.Standby
        standby75 = 75,                 //75.Standby
        standby76 = 76,                 //76.Standby
        standby77 = 77,                 //77.Standby
        standby78 = 78,                 //78.Standby
        standby79 = 79,                 //79.Standby
        standby80 = 80,                 //80.Standby

        standby81 = 81,                 //81.Standby
        standby82 = 82,                 //82.Standby
        standby83 = 83,                 //83.Standby
        standby84 = 84,                 //84.Standby
        standby85 = 85,                 //85.Standby
        standby86 = 86,                 //86.Standby
        standby87 = 87,                 //87.Standby
        standby88 = 88,                 //88.Standby
        standby89 = 89,                 //89.Standby
        standby90 = 80,                 //90.Standby

        standby91 = 91,                 //91.Standby
        standby92 = 92,                 //92.Standby
        standby93 = 93,                 //93.Standby
        standby94 = 94,                 //94.Standby
        standby95 = 95,                 //95.Standby
        standby96 = 96,                 //96.Standby
        standby97 = 97,                 //97.Standby
        standby98 = 98,                 //98.Standby
        standby99 = 99,                 //99.Standby
        standby100 = 100,               //100.Standby
    }
    /// <summary>
    /// 默认情况下自动创建到bin/Debug/Config
    /// </summary>
    [ConfigFile("Config\\Setting.ini")]
    public class Setting : IniConfig<Setting>
    {
        [ConfigSection("PlcInfo1")]
        public string PlcName { get; set; }

        [ConfigSection("PlcInfo1")]
        public string PlcType { get; set; }

        [ConfigSection("PlcInfo1")]
        public string ServerIP { get; set; }

        [ConfigSection("PlcInfo1")]
        public int ServerPort { get; set; }

        public override void SetDefault()
        {
            base.SetDefault();
            PlcType = "汇川";
            ServerIP = "192.168.1.2";
            ServerPort = 9090;
        }
    }
}
