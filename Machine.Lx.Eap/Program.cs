using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine.Lx.Eap
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //   ApplicationConfiguration.Initialize();
            //创建服务容器
            var services = new ServiceCollection();
            //添加服务注册
            MyStartup.AddConfigureServices(services);

            //先用DI容器生成 serviceProvider, 然后通过 serviceProvider 获取Main Form的注册实例
            var serviceProvider = services.BuildServiceProvider();

            var main = serviceProvider.GetRequiredService<Main_Form>();   //主动从容器中获取FormMain实例, 这是简洁写法
            // var formMain = (FormMain)serviceProvider.GetService(typeof(FormMain));  //更繁琐的写法
            Application.Run(main);
        }
      
    }
}
