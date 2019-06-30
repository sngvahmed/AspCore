using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Util
{
    public enum MarketErrorType
    {
        DBERROR = 1,
        UNKNOWN_ERROR = 2
    }

    public class MarketControllerException: Exception
    {
        public string Message { get; set; }
        public MarketErrorType ErrorType { get; set; } = MarketErrorType.UNKNOWN_ERROR;

        public MarketControllerException(String message, MarketErrorType errorType = MarketErrorType.UNKNOWN_ERROR) : base(message)
        {
            this.Message = message;
            this.ErrorType = errorType;
        }

        public dynamic Response
        {
            get
            {
                dynamic res = new ExpandoObject();
                res.Message = Message;
                res.ErrorType = ErrorType.ToString();

                return res;
            }
        }
    }
}
