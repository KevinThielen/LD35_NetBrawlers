using UnityEngine;
using System.Collections.Generic;

public class HandCards : MonoBehaviour {
	
	public GameObject cardPrefab;
	const float START_POS = 200.0f;
	const float CARD_WIDTH = 200.0f;
	const float OFFSET = 10.0f;
		
    Player player;
    
	
	GameObject[] handCards;
	
	
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		player = go.GetComponentInChildren<Player>();
		
		const int maxCardsInHand = Game.MAX_HANDCARDS;	
		handCards = new GameObject[Game.MAX_HANDCARDS];
		
		//create all card slots and disable them
		for(int i = 0; i<maxCardsInHand; i++) {
			handCards[i] = Instantiate<GameObject>(cardPrefab);
			handCards[i].transform.SetParent(transform, false);
			handCards[i].transform.position = new Vector3(START_POS + i * (OFFSET+CARD_WIDTH), 150.0f, 5.0f);
			handCards[i].SetActive(false);
			handCards[i].GetComponentInChildren<Card>().HandIndex = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int numberOfCards = player.CardsInHand;
		for(int i = 0; i<Game.MAX_HANDCARDS; i++) {
			if(i < numberOfCards) {
				handCards[i].SetActive(true);
				handCards[i].GetComponentInChildren<Card>().SetCard(player.GetCardAtIndex(i));
			}
			else 
				handCards[i].SetActive(false);
		}
	}
}
