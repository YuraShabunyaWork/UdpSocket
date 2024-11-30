using System.Net.Sockets;
using System.Text;

using var udpServer = new UdpClient(5555);
Console.WriteLine("Server ON");
while (true)
{
    var result = await udpServer.ReceiveAsync();
    var message = Encoding.UTF8.GetString(result.Buffer);
    Console.WriteLine($"Получено {result.Buffer.Length} байт");
    Console.WriteLine($"Удаленный адрес: {result.RemoteEndPoint}");
    Console.WriteLine(message);
}