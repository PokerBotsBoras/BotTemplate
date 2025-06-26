using System;
using System.Text.Json;
using System.Threading.Tasks;
using PokerBots.Abstractions;

class Program
{
    static async Task Main()
    {
        var bot = new BotTemplate(); // IPokerBot implementation

        string line;
        while ((line = Console.ReadLine()) != null)
        {
            var state = JsonSerializer.Deserialize<GameState>(line);
            if (state == null) continue;

            var action = bot.GetAction(state);
            var json = JsonSerializer.Serialize(action);
            Console.WriteLine(json);
        }
    }
}
