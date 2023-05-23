using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class HasConflictException : Exception
    {
        public HasConflictException(string message) : base(message)
        {
        }

        public HasConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
