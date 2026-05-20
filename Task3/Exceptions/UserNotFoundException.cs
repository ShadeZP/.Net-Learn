using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    internal class UserNotFoundException: Exception
    {
        public UserNotFoundException() : base("User not found") { }
    }
}
