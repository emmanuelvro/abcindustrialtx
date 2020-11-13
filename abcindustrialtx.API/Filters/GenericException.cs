using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace abcindustrialtx.API.Filters
{
    public class GenericException : SystemException
    {
        public string Code { get; set; }
        public object Values { get; set; }

        public GenericException() : base()
        {
        }

        public GenericException(string message) : base(message)
        {
        }

        public GenericException(string code, string message) : base(message)
        {
            Code = code;
        }

        public GenericException(string code, string message, object values) : base(message)
        {
            Code = code;
            Values = values;
        }

        public GenericException(string message, params string[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    
    }
}
