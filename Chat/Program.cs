using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
Console.WriteLine("Enter name: ");
string? userName = Console.ReadLine();
Console.WriteLine("Enter receive port: ");
if (!int.TryParse(Console.ReadLine(), out var localPort)) return;
Console.WriteLine("Enter send port");
if(!int.TryParse(Console.ReadLine(), out var remotePort)) return;
Console.WriteLine();

Task.Run(ReceiveMessageAsync);
await SendMessageAsync();

async Task SendMessageAsync()
{
    using UdpClient sender = new UdpClient();
    Console.WriteLine("Для отправки сообщений введите сообщение и нажмите Enter");

    while(true)
    {
        var message = Console.ReadLine();
        if(string.IsNullOrEmpty(message)) break;
        message = $"{userName}: {message}";
        var data = Encoding.UTF8.GetBytes(message);
        await sender.SendAsync(data, new IPEndPoint(iPAddress, remotePort));
    }
}

async Task ReceiveMessageAsync()
{
    using UdpClient receiver = new UdpClient(localPort);
    while (true)
    {
        var result = await receiver.ReceiveAsync();
        var message = Encoding.UTF8.GetString(result.Buffer);
        Console.WriteLine(message);
    }
}

