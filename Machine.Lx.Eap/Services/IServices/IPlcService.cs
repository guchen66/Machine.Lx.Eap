using Machine.Lx.Eap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Services.IServices
{
    public interface IPlcService
    {
        //读取01 输出线圈
        Task<bool[]> ReadCoilsAsync(IDeviceData deviceInfo, ushort start, ushort end);

        //读取02 输入线圈
        Task<bool[]> ReadInputsAsync(IDeviceData deviceInfo, ushort start, ushort end);

        //读取01 输出寄存器
        Task<ushort[]> ReadHoldingRegistersAsync(IDeviceData deviceInfo, ushort start, ushort end);

        //读取01 输入寄存器
        Task<ushort[]> ReadInputRegistersAsync(IDeviceData deviceInfo, ushort start, ushort end);

        //写入01 单个线圈
        Task WriteCoilsAsync(IDeviceData deviceInfo, bool value);
    }
}
