using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPotions : MonoBehaviour {
	public Sprite[] PotionSprites;
	public Image PotionUI;
	public GameObject potion;
	public int npot;
	void Start(){

	}

	void Update(){
		npot = potion.GetComponent<Potions>().npotions;
		PotionUI.sprite = PotionSprites[npot];

	}

}
