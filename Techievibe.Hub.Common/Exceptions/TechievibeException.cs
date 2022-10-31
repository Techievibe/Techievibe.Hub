using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techievibe.Hub.Common.Exceptions
{
    public class TechievibeException : Exception 
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public object[] Parameters { get; set; }
        public List<string> Errors { get; set; }

        public TechievibeException(List<string> errors, string message)
            : base(message)
        {
            Errors = errors;
        }

        public TechievibeException(string key, string value, params object[] parameters)
            : base(string.Format(value, parameters ?? new string[] { "", "", "" }))
        {
            Key = key;
            Value = value;
            Parameters = parameters;
        }

        public TechievibeException(string message, params object[] parameters)
            : base(string.Format(message, parameters ?? new string[] { "", "", "" }))
        {
            Value = message;
            Parameters = parameters;
        }

        public TechievibeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
