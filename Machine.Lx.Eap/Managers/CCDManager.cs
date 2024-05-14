using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap.Managers
{
    public class CCDManager
    {
        public void Init()
        {
			//读取XML文件本地连接
			try
			{

			}
			catch (Exception)
			{

				throw;
			}
        }

		/// <summary>
		/// 给固定相机发送字符串
		/// </summary>
		/// <param name="ccdId"></param>
		/// <param name="value"></param>
		public void Send(int ccdId,string value)
		{

		}
    }
}
