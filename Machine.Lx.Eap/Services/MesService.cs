using Machine.Lx.Eap.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine.Lx.Eap.Services
{
    public class MesService:IMesService
    {
        private readonly HttpClient _httpClient;

        public MesService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> UploadDataToMesAsync(UpLoadData data)
        {
            try
            {
                // 将数据对象序列化为JSON字符串
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // MES系统的Web API URL
                var url = "http://localhost/MESAPI/cexWebAPIs/InsertSWMTestData";

                // 发送POST请求
                var response = await _httpClient.PostAsync(url, content);

                // 确保HTTP成功状态码
                if (response.IsSuccessStatusCode)
                {
                    // 处理成功的响应
                    return true;
                }
                else
                {
                    // 处理错误响应
                  //  MessageBox.Show("Error: " + response.ReasonPhrase);
                  //  Console.WriteLine("Error: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (HttpRequestException e)
            {
                // 处理异常
              //  Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }
    }
}
