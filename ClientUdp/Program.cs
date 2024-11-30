using System.Net;
using System.Net.Sockets;
using System.Text;

using var udpClient = new UdpClient();
udpClient.Connect(IPAddress.Parse("127.0.0.1"), 5555);
while (true)
{
    string? message = Console.ReadLine();
    byte[] data = Encoding.UTF8.GetBytes(message);
    //IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
    int bytes = await udpClient.SendAsync(data);
    Console.WriteLine($"Оправленно {bytes} байт");
}