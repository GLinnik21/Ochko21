using System;
using System.Collections.Generic;

namespace Laba1
{
	public class Deck
	{
		public Deck(bool isEmpty)
		{
			if (isEmpty) {
				_deck = new List<Card>();
			} else {
				_deck = new List<Card>();
				for (int i = 0; i < 4; i++) {
					for (int j = 1; j <= 13; j++) {
						_deck.Add(new Card(j, (Card.CardSuits)i));
					}
				}
			}
		}
		public void pushCard(Card card)
		{
			_deck.Add(card);
		}

		public Card getRandomCard()
		{
			Card randomCard = null;
			if (_deck.Count > 0) {
				Random rnd = new Random();
				int cardNumber = rnd.Next(0, _deck.Count - 1);
				randomCard = _deck[cardNumber];
				_deck.RemoveAt(cardNumber);
			}
			return randomCard;
		}

		private List<Card> _deck;

		public Card[] cardsArray {
			get {
				return _deck.ToArray();
			}
		}

		public string getDeckString()
		{
			string finalString = "";
			foreach (Card card in _deck) {
				finalString += (card.contents() + " ");
			}
			return finalString;
		}


	}
}
