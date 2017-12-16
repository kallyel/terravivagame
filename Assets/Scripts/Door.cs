using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {
	public int LevelToLoad;
	private Potions pt;
	public int faltapt;
	public int goalspt;
	private GameObject Jogador;

	void Start(){
		Jogador = GameObject.FindGameObjectWithTag ("Player");
		pt = GameObject.FindGameObjectWithTag ("potiontext").GetComponent<Potions> ();
	}
	void OnTriggerEnter2D(Collider2D col){
		faltapt = goalspt - pt.npotions;
		
		if (pt.npotions == goalspt) {
			if (col.CompareTag ("Player")) {
				Application.LoadLevel (Application.loadedLevel + 1);
					} 
		
		} else {
			if (faltapt == 1) {
				pt.InputText.text = ("Falta " + "apenas uma poção!");
			} else {
				pt.InputText.text = ("Faltam " + faltapt + " poções!");
			}
		}


	}



	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			pt.InputText.text = (" ");
		}
	}

	void Update(){
				}
}
