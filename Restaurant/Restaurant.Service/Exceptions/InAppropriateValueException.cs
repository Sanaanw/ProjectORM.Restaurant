using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Exceptions
{
    public class InAppropriateValueException:Exception
    {
        public InAppropriateValueException() { }
        public InAppropriateValueException(string message) : base(message) { }
        public InAppropriateValueException(string message, Exception inner) : base(message, inner) { }
    }
}
