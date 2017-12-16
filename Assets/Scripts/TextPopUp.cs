using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour {
	public Image PopUpText;

	void Start(){
		PopUpText.enabled = false;
	}
	void OnTriggerEnter2D(Collider2D col){
		PopUpText.enabled = true;
	}

	void OnTriggerStay2D(Collider2D col){
		PopUpText.enabled = true;
	}

	void OnTriggerExit2D(Collider2D col){
		PopUpText.enabled = false;
		Destroy (PopUpText);

		}

	}

