using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AP : MonoBehaviour {

	Text text;
	public Player player;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = player.AP.ToString();
	}
}
