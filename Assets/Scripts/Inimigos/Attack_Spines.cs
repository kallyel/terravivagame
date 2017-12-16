using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Spines : MonoBehaviour {
	public Cacto enemyshoot;

	// Use this for initialization
	void Awake() {
		enemyshoot = gameObject.GetComponentInParent<Cacto> ();
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			enemyshoot.Attack ();
		}
	}
}
