using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPopUp : MonoBehaviour {
	public Image PopUpText;
	public float timer = 5;

	float oldTimer;
	public Player player;
	public int botao;
	bool isRunning = false;

	void Start(){
		PopUpText.enabled = false;
		oldTimer = timer;


	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			isRunning = true;
			PopUpText.enabled = true;
		}
	}	

	void Update(){

		if (timer < 0 && isRunning == true) {
			PopUpText.enabled = false;

			isRunning = false;
			PopUpText.enabled = false;
			Destroy (PopUpText);
			this.GetComponent<Collider2D>().enabled = false;

		}
		if (isRunning == true) {
			botao = 1;
			timer -= Time.fixedDeltaTime;

		}
		if (isRunning == false) {
			botao = 0;
		}


	}
	}

