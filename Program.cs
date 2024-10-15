using System;
using System.Threading.Tasks;
using MonsterTradingCardGame.Server;

public class Program
{
    public static async Task Main(string[] args)
    {
        Server server = new Server(8080);
        await server.StartAsync();

    }
}
