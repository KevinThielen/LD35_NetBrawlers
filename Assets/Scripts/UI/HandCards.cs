﻿using UnityEngine;
using System.Collections.Generic;

public class HandCards : MonoBehaviour {
	
	public GameObject cardPrefab;
	const float START_POS = 100.0f;
	const float CARD_WIDTH = 100.0f;
	const float OFFSET = 10.0f;
		
    Player player;
	int numberOfCards = 0;
    
	
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
			handCards[i].transform.position = new Vector3(START_POS + i * (OFFSET+CARD_WIDTH), 60.0f, 5.0f);
			handCards[i].SetActive(false);
		}
		numberOfCards = 0;
	}
	
	// Update is called once per frame
	void Update () {
		int currentNumberOfCards = player.CardsInHand;
		if(numberOfCards != currentNumberOfCards)
		{
			int diff = currentNumberOfCards - numberOfCards;
			handCards[numberOfCards+diff - 1].SetActive(true);
			
			numberOfCards = currentNumberOfCards;		
		}
	}
}