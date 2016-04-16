using UnityEngine;
 using UnityEngine.UI;
using System.Collections;

public class Deck : MonoBehaviour {

	Player player;
	Text deckSizeText;
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		player = go.GetComponentInChildren<Player>();
		
		deckSizeText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		deckSizeText.text = player.DeckSize.ToString();
	}
}
