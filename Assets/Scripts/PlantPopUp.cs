using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPopUp : MonoBehaviour {
	public Image PlantPop;

	public Player player;
	public GameObject b2;

	void Start(){
		PlantPop.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			PlantPop.enabled = true;

		}

	}



	void Update(){
		if (Input.GetKeyDown (KeyCode.S) && PlantPop.enabled == true) {	
			PlantPop.enabled = false;
			Destroy (GameObject.FindGameObjectWithTag ("b2"));




		}
	}
}

