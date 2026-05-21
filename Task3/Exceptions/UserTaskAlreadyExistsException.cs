using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    internal class UserTaskAlreadyExistsException: UserTaskException
    {
        public UserTaskAlreadyExistsException() : base("The task already exists") { }
    }
}
