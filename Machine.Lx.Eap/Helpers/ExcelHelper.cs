using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Lx.Eap.Devices.PLC;
using MiniExcelLibs;
using MiniExcelLibs.Attributes;
using MiniExcelLibs.OpenXml;

namespace Machine.Lx.Eap.Helpers
{
    /// <summary>
    /// Excel操作帮助类
    /// </summary>
    public static class ExcelHelper
    {
        public static void ExecuteDowLoad(string filePath, object value)
        {
            MiniExcel.SaveAs(filePath, value);
        }

        private static IEnumerable<Dictionary<string, object>> RewriteTitle<TEntity>(
            List<TEntity> models
        )
        {
            var dict = new Dictionary<string, object>();
            foreach (var item in models)
            {
                /*  dict.Add("物资Id", item.WareHouseName);
                  dict.Add("物资名称", item.WareHouseName);
                  dict.Add("物资类型", item.ItemType);
                  //  dict.Add("物资单位", item.Amount);
                  dict.Add("价格", item.Price);
                  dict.Add("备注", item.Tag);
                  dict.Add("创建日期", item.CreateTime);
                  dict.Add("操作员Id", item.UserId);
                  dict.Add("操作员", item.AssociatedPerson);
  */
                yield return dict;
            }
        }

        public static void WriteData3()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var path = filePath + "003.xlsx";
            var config = new OpenXmlConfiguration
            {
                DynamicColumns = new DynamicExcelColumn[]
                {
                    new DynamicExcelColumn("id") { Ignore = true },
                    new DynamicExcelColumn("name") { Index = 1, Width = 10 },
                    new DynamicExcelColumn("createdate")
                    {
                        Index = 0,
                        Format = "yyyy-MM-dd",
                        Width = 15
                    },
                    new DynamicExcelColumn("point") { Index = 2, Name = "Account Point" },
                }
            };

            var value = new[]
            {
                new
                {
                    id = 1,
                    name = "Jack",
                    createdate = new DateTime(2022, 04, 12),
                    point = 123.456
                }
            };
            MiniExcel.SaveAs(path, value, configuration: config);
        }

        /// <summary>
        /// 写入附加数据
        /// csv才能追加
        /// </summary>
        public static void WriteAppendData(List<PlcEventRegion> plcDatas)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var path = filePath + "003.csv";
            var config = new MiniExcelLibs.Csv.CsvConfiguration() { NewLine = "\n" };

            if (path == null)
            {
                MiniExcel.SaveAs(path, plcDatas, configuration: config);
            }
            else
            {
                MiniExcel.Insert(path, plcDatas);
            }
        }
    }
}
