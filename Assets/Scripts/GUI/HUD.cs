using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Sprite[] HeartSprites;
	public Image HeartUI;
	public GameObject player;
	public int cur;
	void Start(){
		
	}

	void Update(){
		cur = player.GetComponent<Player>().curHealth;
		HeartUI.sprite = HeartSprites[cur];

	}

}
