using System;
namespace Laba1
{
	public class Card
	{
		public enum CardSuits { CardSuitPeak, CardSuitCross, CardSuitTambourine, CardSuitHeart }

		public Card(int rank, int suit)
		{
			this.rank = rank;
			switch (suit) {
				case (int)CardSuits.CardSuitCross:
					this.suit = '♣';
					break;
				case (int)CardSuits.CardSuitPeak:
					this.suit = '♠';
					break;
				case (int)CardSuits.CardSuitHeart:
					this.suit = '♥';
					break;
				case (int)CardSuits.CardSuitTambourine:
					this.suit = '♦';
					break;

			}
		}

		public Card(int rank, CardSuits suit)
		{
			this.rank = rank;
			switch (suit) {
				case CardSuits.CardSuitCross:
					this.suit = '♣';
					break;
				case CardSuits.CardSuitPeak:
					this.suit = '♠';
					break;
				case CardSuits.CardSuitHeart:
					this.suit = '♥';
					break;
				case CardSuits.CardSuitTambourine:
					this.suit = '♦';
					break;

			}
		}


		private int _rank;
		public int rank {
			get {
				return _rank;
			}
			set {
				if (value >= 1 && value <= 13) {
					_rank = value;
				} else {
					throw new Exception("Wrong rank!");
				}

			}
		}

		public char suit {
			get;
			set;
		}


		public string contents()
		{
			string[] rankStrings = new string[] { "?", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
			return $"{rankStrings[this.rank]}{this.suit}";
		}
	}
}
