# Välkommen till ditt PokerBot-repo!

I `Bot/BotTemplate.cs` hittar du ett exempel på hur en bot kan se ut. Du kan använda den som utgångspunkt eller skapa en egen implementation. Det viktiga är att din bot implementerar `IPokerBot`-interfacet, som finns i NuGet-paketet `PokerBotsBoras.Abstractions`.

Varje gång du pushar till `master`-branchen körs GitHub-workflowen [`build-and-release`](.github/workflows/build-and-release.yml). Den bygger en `.dll` som sedan används av [TournamentRunner](https://github.com/PokerBotsBoras/TournamentRunner) – ett projekt du gärna får klona och testa lokalt. TournamentRunner kör tävlingen mellan alla bottar.

## Installation

Kom ihåg att köra:

```sh
dotnet restore
```

för att installera alla beroenden.
