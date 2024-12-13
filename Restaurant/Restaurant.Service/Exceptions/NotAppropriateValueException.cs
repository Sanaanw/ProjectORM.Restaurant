using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Exceptions
{
    public class NotAppropriateValueException:Exception
    {
        public NotAppropriateValueException() { }
        public NotAppropriateValueException(string message) : base(message) { }
        public NotAppropriateValueException(string message, Exception inner) : base(message, inner) { }
    }
}
