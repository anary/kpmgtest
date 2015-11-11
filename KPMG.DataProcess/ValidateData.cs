using KPMG.Core;
using KPMG.Core.Contract;
using KPMG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.DataProcess
{
    
    public class ValiateData : IValidateData
    {
        IValidate validator;     
        DataPersistance database;

        public ValiateData()
        {
            this.validator = new Validate();
            database= new DataPersistance();
          
            
            
        }

        public ValiateData(IValidate validate, IProcessMessage processor)
        {
            this.validator = validate;
            //this.processor = processor;
        }

        public ValidatedTransactions ValidatedData(IEnumerable<DataDTO> dataList)
        {
            var result = new ValidatedTransactions();
            var failed = new List<DataDTO>();
            var successed = new List<Transaction>();
          
            foreach (var data in dataList)
            {
                
                if (validator.Valiate(data))
                {
                    database.SaveToDb(TransConverter(data));
                }
                else
                {
                    failed.Add(data);
                }
                            
            }
            database.Saved();
            return new ValidatedTransactions()
            {
                FailedTransactions = failed,
              
            };
        }

        private Transaction TransConverter(DataDTO data)
        {
            return new Transaction()
            {
                Account = data.Account,
                Description = data.Description,
                CurrencyCode = data.CurrencyCode,
                Amount = decimal.Parse(data.Amount)
            };

        }
    }

  
}
