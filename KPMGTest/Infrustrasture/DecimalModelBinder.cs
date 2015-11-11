﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMGTest.Infrustrasture
{
    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                //if with period use InvariantCulture
                if (valueResult.AttemptedValue.Contains("."))
                {
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue,
                    System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    //if with comma use CurrentCulture
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue,
                    System.Globalization.CultureInfo.CurrentCulture);
                }

            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}