using UnityEngine;


public class Card : MonoBehaviour {

    int index;
	Game game;
	Player player;
	
	public int HandIndex {
		get { return index;  }
		set { index = value; }
	}
	
	// Use this for initialization
	void Start () {
		game = GameObject.FindGameObjectWithTag("Game").GetComponentInChildren<Game>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDraw() {
		//Play DrawAnimations
	}
	
	void Action() {
		player.PlayCard(index);
	}
	
	public void OnMouseDown()
	{
		if(game.CurrentPlayer == player)
			Action();
	}
}
