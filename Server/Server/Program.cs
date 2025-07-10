using System.Net;
using Server.Worker;
using ServerCore;

namespace Server
{
	class Program
	{
		static async Task Main(string[] args)
		{
			await MatchSubscriberWorker.StartAsync();
			MatchConnectionServerWorker.Start(args);
        }
	}
}
