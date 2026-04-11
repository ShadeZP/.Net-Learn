using System;

namespace task2
{
    public class HelloService
    {
        public string GetMessage(string username)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            return $"{time} Hello, {username}!";
        }
    }
}
