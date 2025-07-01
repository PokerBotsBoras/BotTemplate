# Välkommen till ditt PokerBot-repo!

>Det här projektet är en **template-repo** i organisationen. När du går med i organisationen bör du automatiskt (eller inom kort) få ett eget repo baserat på denna mall.
Om det här redan är ditt repo – toppen! Annars vänta 10 minuter. I värsta fall kan du skapa ett nytt genom att gå till [denna repo-sida](https://github.com/PokerBotsBoras/BotTemplate) och klicka på den gröna knappen **"Use this template"** uppe till höger. Välj sedan "Create new repository" -> välj organisationen som ägare istället för digsjälv, och skriv ett namn som börjar på "bots-".

---

## Installation

Kör följande kommando för att installera alla beroenden:

```sh
dotnet restore
```

---

## Kom igång

I `Bot/BotTemplate.cs` hittar du ett exempel på hur en bot är uppbyggd. Du kan använda den som utgångspunkt eller skriva en egen.

### Du implementerar IPokerBo
Du implementerar gränssnittet IPokerBot. Turneringen kommer att använda din kod, vilket innebär att:

 - ✅ Den exekveras som en fristående process (Sköter TurnamentRunner)

 - ✅ Den får ett JSON-formaterat GameState via stdin (finns i redan i template)

 - ✅ Den måste svara med en JSON-formaterad PokerAction via stdout (detta är redan löst i templaten)

 - ⚠️ Den måste svara inom 1 sekund

 - ‼️ ⚠️ Det är **i din implementation av IPokerBot som all din spelstrategi ska sitta** ⚠️  ‼️.
 
 Implementationen av IpokerBot är egentligen det enda du behöver ändra ör att göra en komplett bot.

 Se mer detaljer i [TournamentRunner](https://github.com/PokerBotsBoras/TournamentRunner)

---

## Reglerna 

**Heads-Up Micro Hold’em** är en förenklad och snabb pokervariant där en hand är bara 2 kort. Varje spelare får en privat kort och delar ett gemensamt – vilket skapar ett koncentrerat läge för strategi, bluffar och snabb bedömning av sannolikheter. Spelet spelas alltid "heads-up" (1 mot 1), vilket gör att varje beslut väger tungt. Reglerna är anpassade för att vara enkla att implementera men tillräckligt komplexa för att skapa intressant botlogik.

Se de [Kompletta reglerna](Docs/GameRules.md) för  **Heads-Up Micro Hold’em**

---

## Submitta din bot

Varje gång du **pushar till `master`-branchen med en tag som börjar med `v`**, t.ex. `v1.0.0`, så körs GitHub-workflowen [`build-and-release`](.github/workflows/build-and-release.yml).
Den bygger en `.dll` som sedan används av [TournamentRunner](https://github.com/PokerBotsBoras/TournamentRunner) – ett projekt du gärna får klona och testa lokalt, då kan du testa och se hur din bot funkar. TournamentRunner kör tävlingen mellan alla bottar.

### Exempel – om du inte använt tags tidigare:

1. Gör dina ändringar och committa till `master`.
2. Skapa en tag som börjar på "v":

   ```sh
   git tag v1.0.0
   ```
3. Pusha taggen till GitHub:

   ```sh
   git push origin v1.0.0
   ```

När det är gjort startar build-processen automatiskt.

