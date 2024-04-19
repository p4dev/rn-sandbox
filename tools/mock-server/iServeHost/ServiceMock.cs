using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;

public static class ServiceMock
{
    public static void RunListener()
    {
        int PORT = 50001;
        UdpClient udpClient = new UdpClient();
        udpClient.EnableBroadcast = true;
        var stringData = GetResourceTextFile("terminals.json");
        var jsonData = JArray.Parse(stringData);
        var data = Encoding.UTF8.GetBytes(jsonData.ToString(Newtonsoft.Json.Formatting.None));

        var task = Task.Run(async () =>
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(3));

            while (await timer.WaitForNextTickAsync())
            {
                Console.WriteLine("Broadcasting terminal list");
                try
                {
                    await udpClient.SendAsync(data, data.Length, new IPEndPoint(IPAddress.Broadcast, PORT));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        });

        task.Wait();
    }

    public static string GetResourceTextFile(string filename)
    {
        string result = string.Empty;
        var assembly = typeof(ServiceMock).Assembly;
        using (var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Resources.{filename}"))
        {
            using (var sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }
        }
        return result;
    }
}

