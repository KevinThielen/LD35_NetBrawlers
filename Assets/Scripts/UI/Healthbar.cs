using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour {

	public Player player;
	Image image;
	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
       image.rectTransform.sizeDelta = new Vector2(260*player.Health / Player.MAX_HEALTH, 35);
	}
}
