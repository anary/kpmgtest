using Excel;
using KPMG.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using KPMG.Core;
using KPMG.Core.Contract;
using KPMG.Data;

namespace KPMG.DataProcess
{
    public static class ExcelData
    {
        public static IExcelDataReader GetExcelDataReader(string path, bool isFirstRowAsColumnName=true)
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader dataReader;

                if (path.EndsWith(".xlsx"))
                    dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);              
                else
                    throw new Exception("The file to be processed is not support");
                dataReader.IsFirstRowAsColumnNames = isFirstRowAsColumnName;
                return dataReader;
            }
        }

        private static DataSet GetExcelDataAsDataSet(string path, bool isFirstRowAsColumnNames=true)
        {
            return GetExcelDataReader(path, isFirstRowAsColumnNames).AsDataSet();
        }

        public static IEnumerable<DataRow> GetData(string path,
             bool isFirstRowAsColumnNames = true)
        {
            return from DataRow row in GetExcelDataAsDataSet(path, isFirstRowAsColumnNames)
                       .Tables[0].Rows
                       
                   select row;
        }
    }

    public class ReadInData : IGetData
    {        
        public IEnumerable<DataDTO> GetData(string path,
            bool isFirstRowAsColumnNames = true)
        {
                      
            if (path.EndsWith(".xlsx"))
            {
                return ExcelData.GetData(path).Select(dataRow => new DataDTO()
                {
                    Account = dataRow["Account"].ToString(),
                    CurrencyCode = dataRow["CurrencyCode"].ToString(),
                    Description = dataRow["Description"].ToString(),
                    Amount = dataRow["Amount"].ToString()
                });
            }
            else
            {
                ICsvDataReader csvData=new CsvDataReader(path);
                csvData.IsFirstRowAsColumnNames = isFirstRowAsColumnNames;
                return csvData.AsDataList();
            }
            
        }
    }

    
    
    
}
