using Server;
using ServerCore;
using System.Net;

namespace Server.Worker;

internal static class MatchConnectionServerWorker
{
    static readonly Listener Listener = new Listener();

    private static void FlushRoom()
    {
        JobTimer.Instance.Push(FlushRoom, 250);
    }

    public static void Start(string[] args)
    {
        // DNS (Domain Name System)
        var ipHost = Dns.GetHostEntry(Config.Host);
        var ipAddr = ipHost.AddressList[0];
        var endPoint = new IPEndPoint(ipAddr, Config.Port);

        Listener.Init(endPoint, () => SessionManager.Instance.Generate());
        Console.WriteLine("Listening...");

        //FlushRoom();
        JobTimer.Instance.Push(FlushRoom);

        while (true)
        {
            JobTimer.Instance.Flush();
        }
    }
}