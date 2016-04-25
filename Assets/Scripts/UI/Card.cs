using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public Text cardName;
	public Text cardCost;
	public Text requiredForm;
	public Text transforms;
	public Text description;
	
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
	public void SetCard(ICard card) {
		cardName.text = card.Name;
		cardCost.text = card.Cost.ToString();
		description.text = card.Description;
		requiredForm.text = card.RequiredForm.ToString();
		transforms.text = card.ShiftsInto.ToString();
	}
	public void OnMouseDown()
	{
		if(game.CurrentPlayer == player)
			Action();
	}
}
