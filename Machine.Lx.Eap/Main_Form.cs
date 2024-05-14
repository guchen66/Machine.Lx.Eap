using Machine.Lx.Eap.Devices.PLC;
using Machine.Lx.Eap.Globals;
using Machine.Lx.Eap.Helpers;
using Machine.Lx.Eap.Models;
using Machine.Lx.Eap.Services.IServices;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine.Lx.Eap
{
    public partial class Main_Form : UIForm
    {
        IPlcService _plcService;
        IMesService _mesService;
        public Main_Form(IPlcService plcService,IMesService mesService)
        {
            InitializeComponent();
            _plcService = plcService;
            _mesService = mesService;
        }


        private async void Main_Form_Load(object sender, System.EventArgs e)
        {
           
           /* var device01 = new Device01
            {
                SlaveId = 1,
                IP = "127.0.0.1",
                Port = 502
            };
            PlcProvider plcProvider=new PlcProvider ();
            string ip= plcProvider.ReadIniAllSection("PlcInfo2").GetKey("ServerIP");
            plcProvider.ReadIniAllSection("PlcInfo2").WriteValue("PlcName","西门子111111");
            await plcProvider.GetPlcDataByLocalExcel();
            var s= await _plcService.ReadCoilsAsync(device01,0,5);
            float Alimit = Convert.ToSingle(Software_Fixed.np_BaseTbx_N[(int)e_BaseTbx_N.RotateAngelLimit]);
            IniFile ini = new IniFile(DirEx.CurrentDir() + "Config\\Setting.ini");
            string name = ini.ReadString("PlcInfo2", "PlcName", "");
            ini.Write("PlcInfo2", "ServerPort", 0);
            Setting.Current.Load();*/
            // var ip= Setting.Current.ServerIP;
           
         //   Setting.Current.Save();
            //硬件初始化
            InitHardware();
            //PLC初始化
           // InitPlc;
        }

        private void InitHardware()
        {
            Thread thread = new Thread(() => 
            {
                if (GlobalCCD.CCD_ConnFlag)
                {
                    GlobalCCD.CCDManager.Init();
                }
            });
        }

        private async void UpLoad_Load(object sender, System.EventArgs e)
        {
            // 假设这是在窗口加载时执行
            bool success = await _mesService.UploadDataToMesAsync(new UpLoadData());
            if (success)
            {
                MessageBox.Show("数据上传成功");
            }
            else
            {
                MessageBox.Show("数据上传失败");
            }
        }
    }
}
