using Microsoft.AspNetCore.SignalR.Client;

const string apiKey = "68f3a6db-36b8-411f-99c9-7f4a69a524ea";  
const string hubUrl = "https://localhost:7190/chat-hub";  

var connection = new HubConnectionBuilder()
    .WithUrl(hubUrl, options =>
    {
        options.Headers.Add("ApiKey", apiKey);
    })
    .Build();

connection.On<string>("ReceiveMessage", (message) =>
{
    Console.WriteLine($"Message received: {message}");
});

try
{
    await connection.StartAsync();
    Console.WriteLine("Connected...");

    await connection.InvokeAsync("JoinGroup", "ConsoleAppGroup");

    Console.WriteLine("Press Enter to exit.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error connecting to the hub: {ex.Message}");
}

Console.ReadLine();