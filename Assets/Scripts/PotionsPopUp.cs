using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsPopUp : MonoBehaviour {
	public Image PotionPopUp;

	public Player player;
	public GameObject b2;

	void Start(){
		PotionPopUp.enabled = false;



	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			PotionPopUp.enabled = true;

		}

	}



	void Update(){
		if (Input.GetKeyDown (KeyCode.S) && GameObject.FindGameObjectWithTag ("barreira") == true) {		
			PotionPopUp.enabled = false;
			Destroy (GameObject.FindGameObjectWithTag ("barreira"));
			Destroy (GameObject.FindGameObjectWithTag ("sobre"));
			b2.GetComponent<Collider2D>().enabled = true;
		}
	}
}

