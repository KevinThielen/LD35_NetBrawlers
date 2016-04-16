using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public const int MAX_HEALTH = 100;
    
	List<ICard> handCards;
	Stack<ICard> deck;
	
	Stack<ICard> selectedCards;
	//needed to rollback later
	Stack<int> indices;
	Game game;
	int health;
	
	// GETTER / SETTER
	public int Health {
		get { return health; }
	}
	public int CardsInHand {
		get { return handCards.Count; } 
	}
	
	public int DeckSize {
		get { return deck.Count; }
	}
	/////////////////////
	// Use this for initialization
	void Start () {
		handCards = new List<ICard>();
		deck = new Stack<ICard>();
		selectedCards = new Stack<ICard>();
		indices = new Stack<int>();
		
		game = GameObject.FindGameObjectWithTag("Game").GetComponentInChildren<Game>();
	}
	
	public void SetDeck(Stack<ICard> deck) {
		this.deck = deck;
	}
	public void DrawCard()
	{
		if(deck.Count > 0 && CardsInHand < Game.MAX_HANDCARDS)
			handCards.Insert(CardsInHand, deck.Pop());
	}
	
	public void PlayCard(int index) {
		if(index >= 0 && index < CardsInHand) {	
			selectedCards.Push(handCards[index]);
			handCards.RemoveAt(index);
			indices.Push(index);
		}
	}
	
	public void Damage(int amount) {
		health -= amount;
	}
	
	public void ExecuteTurn() {
		game.PlayCards(this, selectedCards);
		selectedCards.Clear();
		indices.Clear();
	}
}
