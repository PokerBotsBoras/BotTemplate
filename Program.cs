using System;
using System.Text.Json;
using System.Threading.Tasks;
using PokerBots.Abstractions;

class Program
{
    static IPokerBot CreateBot() => new BotTemplate();

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
                    Console.WriteLine(JsonSerializer.Serialize(new PokerAction { ActionType = PokerActionType.Fold }));
                    continue;
                }

                var action = bot.GetAction(state);
                // Only set Amount for Raise, not for Call or Fold
                if (action.ActionType != PokerActionType.Raise)
                {
                    action.Amount = null;
                }
                var json = JsonSerializer.Serialize(action);
                Console.WriteLine(json);
            }
            catch (Exception)
            {
                Console.WriteLine(JsonSerializer.Serialize(new PokerAction { ActionType = PokerActionType.Fold }));
            }
        }
    }
}
