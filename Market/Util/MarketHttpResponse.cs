using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Util
{
    public enum MarketResponseType
    {
        SUCCESS = 1,
        NOT_FOUND = 2,
        FOUND = 3
    }

    public class MarketHttpResponse <T>
    {
        private T _Result;
        private int _Length;

        private MarketResponseType _Type;

        public String Type {
            get {
                return _Type.ToString();
            }
        }

        public MarketHttpResponse(T result, MarketResponseType type, int length = 0)
        {
            _Result = result;
            _Type = type;
            if (length != 0) _Length = length;
        }

        public dynamic Result
        {
            get
            {
                dynamic res = new ExpandoObject();
                res.Result = _Result;

                if (_Length != 0)
                    res.Length = _Length;

                return res;
            }
        }
    }
}
