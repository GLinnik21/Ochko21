using System;
using System.Collections.Generic;

namespace Laba1
{
	public class Game
	{
		
		private class Player
		{
			public Player()
			{
				deck = new Deck(true);
				points = 0;
				aceList = new List<Card>();
			}

			public string name {
				get;
				set;
			}

			public int points {
				get;
				set;
			}

			public Deck deck {
				get;
				private set;
			}

			List<Card> aceList;

			private void recountPoints()
			{
				if (points > 21)
				{
					foreach (Card card in deck.cardsArray) {
						if (card.rank == 1 && !aceList.Contains(card) && points > 21) {
							points -= 10;
							aceList.Add(card);
						}
					}
				}
			}

			public void drawCard(Card card)
			{
				deck.pushCard(card);

				switch (card.rank) {
					case 1: this.points += 11; break;
					case 11: this.points += 2; break;
					case 12: this.points += 3; break;
					case 13: this.points += 4; break;
					default: this.points += card.rank; break;
				}
				recountPoints();
			}
		}

		public Game(int players)
		{
			if (players < 2 && players > 10) {
				throw new Exception("Wrong number of players!");
			}
			playersArray = new Player[players];
			playingDeck = new Deck(false);
			timesPlayed = 0;
			for (int i = 0; i < playersArray.Length; i++) {
				playersArray[i] = new Player();
				playersArray[i].name = "Player " + i;
			}

			try {
				if (stats.Count == 0);
			} catch {
				stats = new Dictionary<Player, int>();
			}
			
		}

		Player[] playersArray;
		Deck playingDeck;
		int playerIndex, timesPlayed;
		static Dictionary<Player, int> stats;

		public void startGame()
		{
			Random rnd = new Random();
			playerIndex = rnd.Next(0, playersArray.Length);
			foreach (Player player in playersArray) {
				player.drawCard(playingDeck.getRandomCard());
				player.drawCard(playingDeck.getRandomCard());
				if (!stats.ContainsKey(player)) {
					stats.Add(player, 0);
				}
			}
			turn();
		}

		void turn()
		{

			Player tempPlayer = playersArray[playerIndex];
			Console.WriteLine("Pass to " + tempPlayer.name);
			Console.ReadLine();
			while (true) {
				if (tempPlayer.points == 21) { Console.WriteLine("OCHKO!"); endGame(); return; }
				Console.WriteLine("You have these cards: " + tempPlayer.deck.getDeckString() +
								  " It's " + tempPlayer.points + " points!");
				Console.WriteLine("You can: (1)Draw or (2)Pass");
				string choise = Console.ReadLine();

				if (choise == "1") {
					Card drownCard = playingDeck.getRandomCard();
					tempPlayer.drawCard(drownCard);
					Console.WriteLine("You've drown this card: " + drownCard.contents());
				} else if (choise == "2") {
					nextPlayer();
					return;
				}
			}
		}

		void nextPlayer()
		{
			Console.Clear();
			playerIndex = playerIndex == playersArray.Length - 1 ? 0 : ++playerIndex;
			if (++timesPlayed == playersArray.Length) {
				endGame();
			} else {
				turn();
			}
		}
		void endGame()
		{
			Player tempWinner = null;
			int MAX = 0;
			foreach (Player player in playersArray) {
				if (MAX < player.points && player.points <= 21) {
					MAX = player.points;
					tempWinner = player;
				}
			}

			if (MAX == 0) {
				Console.WriteLine("No winners");
			} else {
				stats[tempWinner]++;
				foreach (Player player in playersArray) {
					if (MAX == player.points && player != tempWinner) {
						Console.WriteLine(player.name + " wins with " + player.points + " points");
						stats[player]++;
					}
				}
				foreach (Player player in playersArray) {
					Console.WriteLine(player.name + " has " + player.points + " points");
				}
			}
			Console.WriteLine();
			Console.WriteLine("Stats:");
			foreach (Player player in playersArray) {
				Console.WriteLine($"{player.name} — {stats[player]}");
			}
		}

	}
}
