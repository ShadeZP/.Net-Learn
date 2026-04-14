using SharedServiceUtils;

// dotnet run {name}

var service = new HelloService();

string username = args.Length > 0 ? args[0] : "Guest";

string message = service.GetMessage(username);

Console.WriteLine(message);