using System;
using PokerBots.Abstractions;

public class BotTemplate : IPokerBot
{
    private static readonly Random rng = new();

    public string Name => "BotTemplate";

    // GetAction is called by the game runner, an you need to return what action the bot should take, based on the GameState
    public PokerAction GetAction(GameState state)
    {
        bool random = rng.NextDouble() > 0.5d;
        if (state.ToCall == 0)
        {
            if (random && state.MyStack >= state.MinRaise)
            {
                return new PokerAction { ActionType = PokerActionType.Raise, Amount = state.MinRaise };
            }
            else
            {
                return new PokerAction { ActionType = PokerActionType.Call };
            }
        }
        else
        {
            if (random || state.MyStack < state.MinRaise)
                return new PokerAction { ActionType = PokerActionType.Fold };
            else
                return new PokerAction { ActionType = PokerActionType.Call, Amount = state.MinRaise };
        }
    }
}
