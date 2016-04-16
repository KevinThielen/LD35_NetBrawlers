using UnityEngine;


public class Card : MonoBehaviour {

	public ICard card;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDraw() {
		//Play DrawAnimations
	}
	
	void Action() {
		card.Action();
	}
	
	public void OnMouseDown()
	{
		if(card != null)
			Action();
	}
}
