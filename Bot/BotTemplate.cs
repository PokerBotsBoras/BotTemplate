using System;
using PokerBots.Abstractions;

public class BotTemplate : IPokerBot
{
    private static readonly Random rng = new();

    public string Name => "BotTemplate";

    // GetAction is called by the game runner, you need to return what action the bot should take, based on the GameState
    public PokerAction GetAction(GameState state)
    {
        // Minimal bot: always calls if possible, otherwise folds. Only raises if required by rules.
        // Reads state.CommunityCard to conform to abstraction, but does not use it for logic.
        var community = state.CommunityCard; // Read but ignore
        if (state.ToCall == 0)
        {
            if (state.MyStack >= state.MinRaise && state.MinRaise > 0)
                return new PokerAction { ActionType = PokerActionType.Raise, Amount = state.MinRaise };
            else
                return new PokerAction { ActionType = PokerActionType.Call };
        }
        else
        {
            if (state.ToCall <= state.MyStack)
                return new PokerAction { ActionType = PokerActionType.Call };
            else
                return new PokerAction { ActionType = PokerActionType.Fold };
        }
    }
}
