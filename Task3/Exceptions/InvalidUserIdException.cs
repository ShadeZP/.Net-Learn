using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    internal class InvalidUserIdException: Exception
    {
        public InvalidUserIdException() : base("Invalid userId") { }
    }
}
