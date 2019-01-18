using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiparisEnt.WebUI.Infrastructure.Errors
{
    public class JsonError
    {


        public static ErrorField SetMessage(string message, string errorType)
        {
            ErrorField error = new ErrorField
            {
                ErrorType = errorType,
                Message = message
            };
            return error;
        }
    }

}

public class ErrorField
{
    public string Message { get; set; }
    public string ErrorType { get; set; }
}