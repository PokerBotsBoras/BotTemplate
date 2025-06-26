using System;
using System.Text.Json;
using System.Threading.Tasks;
using PokerBots.Abstractions;

class Program
{
    static IPokerBot CreateBot() => new BotTemplate(); // Replace with bot class

    static async Task Main()
    {
        IPokerBot bot = CreateBot();

        string? line;
        while ((line = Console.ReadLine()) != null)
        {
            line = line.Trim();

            if (line == "__name__")
            {
                Console.WriteLine(bot.Name);
                continue;
            }

            if (line == "__reset__")
            {
                bot = CreateBot();
                Console.WriteLine("OK");
                continue;
            }

            try
            {
                var state = JsonSerializer.Deserialize<GameState>(line);
                if (state == null)
                {
                    Console.WriteLine("{\"ActionType\":\"Fold\"}");
                    continue;
                }

                var action = bot.GetAction(state);
                var json = JsonSerializer.Serialize(action);
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{\"ActionType\":\"Fold\"}"); // Safe fallback
            }
        }
    }
}
