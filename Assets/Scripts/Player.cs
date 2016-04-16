using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    Stack<ICard> handCards;
	Stack<ICard> deck;
	
	// GETTER / SETTER
	public int CardsInHand {
		get { return handCards.Count; } 
	}
	
	public int DeckSize {
		get { return deck.Count; }
	}
	/////////////////////
	// Use this for initialization
	void Start () {
		handCards = new Stack<ICard>();
		deck = new Stack<ICard>();
	}
	
	public void SetDeck(Stack<ICard> deck) {
		this.deck = deck;
	}
	public void DrawCard()
	{
		if(deck.Count > 0)
			handCards.Push(deck.Pop());
	}
}
