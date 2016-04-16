using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public const int MAX_HANDCARDS = 7;

	Player player;
	Player opponent;
	Stack<IAction> actionStack;
	int turnCounter = 0;
	bool waitForAction;
	Player currentPlayer;
	
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
			return player;
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
		
		actionStack = new Stack<IAction>();
		
		StartGame();
	}
	
	void StartGame() {
		actionStack.Clear();
		//set deck for both players 
		Stack<ICard> deck = new Stack<ICard>();
		for(int i = 0; i<30; i++)
			deck.Push(CardFactory.Instance.getCard("SwordAttack"));
		player.SetDeck(deck);
		
		deck = new Stack<ICard>();
		for(int i = 0; i<30; i++)
			deck.Push(CardFactory.Instance.getCard("SwordAttack"));
		opponent.SetDeck(deck);
/*	
		Random.InitState(System.Environment.TickCount);
		
		int firstPlayer = Random.Range(0, 2); 
		if(firstPlayer == 0)
			currentPlayer = player;
		else 
			currentPlayer = opponent;
			*/
		currentPlayer = player;
		for(int i = 0; i<5; i++)			
			actionStack.Push(new DrawCardAction());
			
		actionStack.Push(new EndTurnAction());
		
		for(int i = 0; i<5; i++)			
			actionStack.Push(new DrawCardAction());
		
		actionStack.Push(new EndTurnAction());
	}
	
    void StartTurn() {
	   WaitForAction = false;
	   turnCounter++;
	   Debug.Log("Start Turn: "+turnCounter);
	 
	 // Turn Sequence: Draw a Card -> Select Actions -> Execute Actions -> End Turn
	   actionStack.Push(new EndTurnAction());
	  if(currentPlayer != opponent)
	   actionStack.Push(new WaitForAction());
	   actionStack.Push(new DrawCardAction());
    }
	public void PlayCards(Player player, Stack<ICard> playedCards)
	{
		if(waitForAction && player == currentPlayer)
		{
			//validate played cards
			foreach(ICard card in playedCards) {
				foreach(IAction action in card.Actions())
				actionStack.Push(action);
			}
			
			actionStack.Push(new ExecuteTurn());
		}
	}
	
	public void ChangeCurrentPlayer() {
		if(currentPlayer == player)
			currentPlayer = opponent;
		else
			currentPlayer = player;
	}
	// Update is called once per frame
	void Update () {		
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
