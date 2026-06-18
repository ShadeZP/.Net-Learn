using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public abstract class UserTaskException : Exception
    {
        protected UserTaskException(string message) : base(message) { }
    }
}
