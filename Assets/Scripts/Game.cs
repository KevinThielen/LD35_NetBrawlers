using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public const int MAX_HANDCARDS = 6;

	Player player;
	Player opponent;
	Stack<IAction> actionStack;
	int turnCounter = 0;
	bool waitForAction;
	Player currentPlayer;
	bool gameOver;
	float gameOverTimer;
	
	bool initialized = false;
	//   GETTER / SETTER
	public Player CurrentPlayer {
		get { return currentPlayer; }
	}
	
	public Player Player {
		get { return player; }
	}
	public Player Opponent {
		get { return opponent; }
	}
	
	public bool WaitForAction {
		get { return waitForAction;  }
		set { waitForAction = value; }
	}

    public Player getOtherPlayer(Player player) {
		if(this.player == player)
			return opponent;
		else 
			return this.player;
	}

	void Start () {
		//find player
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		if(playerObject != null) {
			player = playerObject.GetComponentInChildren<Player>();		
		}
		else {
			Debug.Log("Player GameObject not found!");
		}
		
		//find opponent
		GameObject opponentObject = GameObject.FindGameObjectWithTag("Opponent");
		if(opponentObject != null) {
			opponent = opponentObject.GetComponentInChildren<Player>();		
		}
		else {
			Debug.Log("Opponent GameObject not found!");
		}
		initialized = false;

	}
	
	void Reset() {
		actionStack = new Stack<IAction>();
		turnCounter = 0;
	initialized = true;
		gameOverTimer = 3.0f;
		gameOver = false;
		player.Reset();
		opponent.Reset();
		StartGame();
		player.AP = 5;
	    opponent.AP = 5;
	}
	
	void StartGame() {
		actionStack.Clear();
		waitForAction = false;
		//set deck for both players 
		Stack<ICard> deck = new Stack<ICard>();
		for(int i = 0; i<30; i++) {
			deck.Push(CardFactory.Instance.getCard("Tail Whip"));
		    deck.Push(CardFactory.Instance.getCard("Speardash"));
			deck.Push(CardFactory.Instance.getCard("Slash"));
			deck.Push(CardFactory.Instance.getCard("FlyingPunch"));
		    deck.Push(CardFactory.Instance.getCard("Blast Punch"));
			deck.Push(CardFactory.Instance.getCard("Serious Edition: Serious Punch"));
		    deck.Push(CardFactory.Instance.getCard("Blast Punch"));
			deck.Push(CardFactory.Instance.getCard("Fireblast"));
			deck.Push(CardFactory.Instance.getCard("Pierce Shot"));
			deck.Push(CardFactory.Instance.getCard("Yellowblast"));
			deck.Push(CardFactory.Instance.getCard("BOOM"));
			deck.Push(CardFactory.Instance.getCard("Blast"));
			deck.Push(CardFactory.Instance.getCard("Dash Attack"));
		}
		player.SetDeck(deck);
		player.Form = EForm.RED;
		
		deck = new Stack<ICard>();
		for(int i = 0; i<30; i++) {
			deck.Push(CardFactory.Instance.getCard("Tail Whip"));
		    deck.Push(CardFactory.Instance.getCard("Speardash"));
			deck.Push(CardFactory.Instance.getCard("Slash"));
			deck.Push(CardFactory.Instance.getCard("FlyingPunch"));
		    deck.Push(CardFactory.Instance.getCard("Blast Punch"));
			deck.Push(CardFactory.Instance.getCard("Serious Edition: Serious Punch"));
		    deck.Push(CardFactory.Instance.getCard("Blast Punch"));
			deck.Push(CardFactory.Instance.getCard("Fireblast"));
			deck.Push(CardFactory.Instance.getCard("Pierce Shot"));
			deck.Push(CardFactory.Instance.getCard("Yellowblast"));
			deck.Push(CardFactory.Instance.getCard("BOOM"));
			deck.Push(CardFactory.Instance.getCard("Blast"));
			deck.Push(CardFactory.Instance.getCard("Dash Attack"));
			
		}
		opponent.SetDeck(deck);
	    opponent.Form = EForm.YELLOW;
		Random.InitState(System.Environment.TickCount);
		
		int firstPlayer = Random.Range(0, 2); 
		if(firstPlayer == 0)
			currentPlayer = player;
		else 
			currentPlayer = opponent;
			
		for(int i = 0; i<5; i++)			
			actionStack.Push(new DrawCardAction());
			
		actionStack.Push(new EndTurnAction());
		
		for(int i = 0; i<5; i++)			
			actionStack.Push(new DrawCardAction());
		
		actionStack.Push(new EndTurnAction());
	}
	
    void StartTurn() {
	   WaitForAction = false;
	   currentPlayer.AP += 3;
	   turnCounter++;
	 
	 // Turn Sequence: Draw a Card -> Select Actions -> Execute Actions -> End Turn
	  actionStack.Push(new EndTurnAction());
	   actionStack.Push(new PlayAnimation("idle"));
	   actionStack.Push(new  RunBack(1, 10));
	   actionStack.Push(new PlayAnimation("run"));

	  if(currentPlayer == player) {
		 currentPlayer.ShowUI(); 
	  } 
	   actionStack.Push(new WaitForAction());
	   actionStack.Push(new DrawCardAction());
    }
	public void PlayCards(Player player, Stack<ICard> playedCards)
	{
		if(waitForAction)
		{
			EForm predictedForm = CurrentPlayer.Form;
			//validate played cards
			foreach(ICard card in playedCards) {
				if(CurrentPlayer.AP >= card.Cost && (card.RequiredForm == EForm.NONE || predictedForm == card.RequiredForm)) {
					foreach(IAction action in card.Actions()) {
						actionStack.Push(action);
					}
						if(card.ShiftsInto != EForm.NONE)
							predictedForm = card.ShiftsInto;
						
						CurrentPlayer.AP -= card.Cost;
				}
			}	
			actionStack.Push(new ExecuteTurn());
		}
	}
	public void PlayAudio(string name) {
		GetComponent<AudioSource>().PlayOneShot(AudioDatabase.Instance.getAudio(name), 0.7f);
	}
	
	void checkWinCondition() {
		if(player.Health <= 0)
		{
			Debug.Log("You LosT");

			gameOver = true;
		}
		else if (opponent.Health <= 0)
		{
			Debug.Log("You Won");
		
			gameOver = true;
		}
	}
	public void ChangeCurrentPlayer() {
		currentPlayer.PutForeground(false);
		if(currentPlayer == player)
			currentPlayer = opponent;
		else
			currentPlayer = player;
			
		currentPlayer.PutForeground(true);
	}
	// Update is called once per frame
	void FixedUpdate () {		
		
		if(!initialized)
			Reset();
			
		if(gameOver) {
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0)
				Reset();
			return;
		}
		else 
		checkWinCondition();
		
		if(waitForAction && currentPlayer == opponent)
	    	currentPlayer.AIMove();
		if(actionStack.Count > 0) {
			if(actionStack.Peek().Execute(this)) {
				actionStack.Pop();
			}		
		}
		else {
			StartTurn();
		}
	}
}
