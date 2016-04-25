using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public const int MAX_HEALTH = 100;
    public const int AP_GAIN = 1;
	
	List<ICard> handCards;
	Stack<ICard> deck;
	
	Stack<ICard> selectedCards;
	//needed to rollback later
	Stack<int> indices;
	Game game;
	EForm currentForm;
	string animationString;
	
	int health;
	int ap;
	Vector2 spawnPosition;
	public GameObject pipeline;
	
	// GETTER / SETTER
	public EForm Form {
		get { return currentForm; }
		set { currentForm = value; }
	}
	
	public string Animation {
		get { return animationString; }
		set 
		{
			 animationString = value;
			 GetComponentInChildren<SpriteRenderer>().sprite = SpriteDatabase.Instance.getAnimation(value, currentForm);
		}
	}
	
	public Vector2 Position {
		get { return new Vector2(transform.position.x, transform.position.y); }
		set { transform.position = new Vector3(value.x, value.y, 1); }
	}
	
	public Vector2 SpawnPosition {
		get { return new Vector2(spawnPosition.x, spawnPosition.y); }
	}
	public int AP {
		get { return ap; }
		set { ap = value; }
	}
	
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
		spawnPosition = Position;
		game = GameObject.FindGameObjectWithTag("Game").GetComponentInChildren<Game>();
	}
	
	public void Reset(EForm startForm = EForm.GRAY) {
		handCards = new List<ICard>();
		deck = new Stack<ICard>();
		selectedCards = new Stack<ICard>();
		indices = new Stack<int>();
		health = MAX_HEALTH;
		Form = EForm.GRAY; 
		Position = SpawnPosition;

		ap = 0;
	}
	
	public void SetDeck(Stack<ICard> deck) {
		this.deck = deck;
	
	}
	public void DrawCard()
	{
		if(deck.Count > 0 && CardsInHand < Game.MAX_HANDCARDS)
			handCards.Insert(CardsInHand, deck.Pop());
	}
	
	public void AddAP(int amount) {
		AP += amount;
	}
	public void PlayCard(int index) {
		if(index >= 0 && index < CardsInHand) {	
			//validate card
				selectedCards.Push(handCards[index]);
				handCards.RemoveAt(index);
				indices.Push(index);
			
		}
	}
	
	public ICard GetCardAtIndex(int index) {
		return handCards[index];
	}
	public void Damage(int amount) {
		health -= amount;
	}
	
	public void ShowUI() {
		pipeline.SetActive(true);
	}
	public void ExecuteTurn() {
		game.PlayCards(this, selectedCards);
		selectedCards.Clear();
		indices.Clear();
		
		if(pipeline)
			pipeline.SetActive(false);
	}
	
	public void AIMove() {
		int apSum = 0;
		for(int i = 0; i<handCards.Count; i++) {
			if(ap >= handCards[i].Cost + apSum) {
				apSum += handCards[i].Cost;
				PlayCard(i);
				i-=1;
			}
		}
		
		ExecuteTurn();
	}
	
	public void PutForeground(bool foreground) {
		if(foreground)
			transform.position = new Vector3(Position.x, Position.y, -1.0f);
		else 
			transform.position = new Vector3(Position.x, Position.y, 1.0f);
	}
	public void Move(float x, float y) {
		transform.Translate(x*Time.deltaTime, y* Time.deltaTime, 0);
	}
}
