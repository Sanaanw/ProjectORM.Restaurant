using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Exceptions
{
    public class WrongIntervalException : Exception
    {
        public WrongIntervalException() { }
        public WrongIntervalException(string message) : base(message) { }
        public WrongIntervalException(string message, Exception inner) : base(message, inner) { }
    }
}
