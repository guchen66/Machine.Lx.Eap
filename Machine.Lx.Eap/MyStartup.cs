using Microsoft.Extensions.DependencyInjection;
using Machine.Lx.Eap.Services;
using Machine.Lx.Eap.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Lx.Eap
{
    public class MyStartup
    {
        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddConfigureServices(IServiceCollection services)
        {
            // services.AddSingleton<ILoginService, LoginService>();
            //批量注入可以使用Scrutor或者自己封装
            //  services.AddScoped<YlbBio>();//

            services.AddScoped(typeof(Main_Form));

            services.AddSingleton<ICCDService, CCDService>();
            services.AddSingleton<IPlcService, PlcService>();
            services.AddSingleton<IMesService, MesService>();
            services.AddSingleton<IRFidService, RFidService>();
        }
    }
}
