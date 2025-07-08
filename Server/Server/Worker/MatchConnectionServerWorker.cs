using Server;
using ServerCore;
using System.Net;

public class MatchConnectionServerWorker
{
    static Listener _listener = new Listener();

    static void FlushRoom()
    {
        JobTimer.Instance.Push(FlushRoom, 250);
    }

    public static void Start(string[] args)
    {
        // DNS (Domain Name System)
        IPHostEntry ipHost = Dns.GetHostEntry(Config.Host);
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint endPoint = new IPEndPoint(ipAddr, Config.Port);

        _listener.Init(endPoint, () => { return SessionManager.Instance.Generate(); });
        Console.WriteLine("Listening...");

        //FlushRoom();
        JobTimer.Instance.Push(FlushRoom);

        while (true)
        {
            JobTimer.Instance.Flush();
        }
    }
}