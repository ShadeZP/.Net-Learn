namespace SharedService
{
    public class NameService
    {
        public string GetName(string username)
        {
            return username.Length > 0 ? username : "Guest";
        }
    }
}
