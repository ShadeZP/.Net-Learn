using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    internal class UserNotFoundException: UserTaskException
    {
        public UserNotFoundException() : base("User not found") { }
    }
}
