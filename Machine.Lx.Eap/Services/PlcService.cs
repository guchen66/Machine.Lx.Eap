using Machine.Lx.Eap.Devices.PLC;
using Machine.Lx.Eap.Models;
using Machine.Lx.Eap.Services.IServices;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine.Lx.Eap.Services
{
    public class PlcService : IPlcService
    {
        private ModbusIpMaster master;

        public PlcService()
        {
            Init();
        }
        public void Init()
        {
            PlcProvider plcProvider = new PlcProvider();
            string Ip = plcProvider.ReadIniAllSection("PlcInfo2").GetKey("ServerIP");
            string Port = plcProvider.ReadIniAllSection("PlcInfo2").GetKey("ServerPort");
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(Ip, int.Parse(Port));
                if (tcpClient.Connected)
                {
                    master = Modbus.Device.ModbusIpMaster.CreateIp(tcpClient);
                }
                else
                {
                    MessageBox.Show("连接失败");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"连接失败{ex.Message}");
            }
           
        }

        public async Task<bool[]> ReadCoilsAsync(IDeviceData deviceData, ushort start, ushort end)
        {
            return await master.ReadCoilsAsync(deviceData.SlaveId, start, end);
          
        }

        public async Task<bool[]> ReadInputsAsync(IDeviceData deviceData, ushort start, ushort end)
        {
            return await master.ReadInputsAsync(deviceData.SlaveId, start, end);
        }

        public async Task<ushort[]> ReadHoldingRegistersAsync(IDeviceData deviceData, ushort start, ushort end)
        {
            return await master.ReadHoldingRegistersAsync(deviceData.SlaveId, start, end);
        }

        public async Task<ushort[]> ReadInputRegistersAsync(IDeviceData deviceData, ushort start, ushort end)
        {
            return await master.ReadInputRegistersAsync(start, end);
        }

        public async Task WriteCoilsAsync(IDeviceData deviceData, bool value)
        {
            await master.WriteSingleCoilAsync(0, value);

            /*   // 确保在调用前，ModbusIpMaster 仍然连接着
               if (_masterClient.IsConnected())
               {
                   await _master.WriteSingleCoilAsync(coilAddress, value);
               }
               else
               {
                   throw new InvalidOperationException("Modbus master is not connected.");
               }*/
        }
    }
}
