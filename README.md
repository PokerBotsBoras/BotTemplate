# Välkommen till ditt PokerBot-repo!

Det här projektet är en **template-repo** i organisationen. När du går med i organisationen bör du automatiskt (eller inom kort) få ett eget repo baserat på denna mall.
Om det här redan är ditt repo – toppen! Annars vänta 10 minuter. I värsta fall kan du skapa ett nytt genom att gå till [denna repo-sida](https://github.com/PokerBotsBoras/BotTemplate) och klicka på den gröna knappen **"Use this template"** uppe till höger. Välj sedan "Create new repository" -> välj organisationen som ägare, och skriv ett namn som börjar på "bots-".

---

## Installation

Kör följande kommando för att installera alla beroenden:

```sh
dotnet restore
```

---

## Kom igång

I `Bot/BotTemplate.cs` hittar du ett exempel på hur en bot är uppbyggd. Du kan använda den som utgångspunkt eller skriva en egen.
Det viktiga är att din bot implementerar `IPokerBot`-interfacet som finns i NuGet-paketet `PokerBotsBoras.Abstractions`.

---

## Submitta din bot

Varje gång du **pushar till `master`-branchen med en tag som börjar med `v`**, t.ex. `v1.0.0`, så körs GitHub-workflowen [`build-and-release`](.github/workflows/build-and-release.yml).
Den bygger en `.dll` som sedan används av [TournamentRunner](https://github.com/PokerBotsBoras/TournamentRunner) – ett projekt du gärna får klona och testa lokalt. TournamentRunner kör tävlingen mellan alla bottar.

### Exempel – om du inte använt tags tidigare:

1. Gör dina ändringar och committa till `master`.
2. Skapa en tag:

   ```sh
   git tag v1.0.0
   ```
3. Pusha taggen till GitHub:

   ```sh
   git push origin v1.0.0
   ```

När det är gjort startar build-processen automatiskt.

