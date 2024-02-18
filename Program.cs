

using casino_Work;
using casino_Work.Games;


//List<IGame> games = new List<IGame>();
//games.Add(new Blacjack());
//games.Add(new Poker());


IBetting betting = new Betting(new List<IGame> () {new Blacjack(), new Slot() } );

betting.games.Add(new Rulete());
betting.SelectGame();