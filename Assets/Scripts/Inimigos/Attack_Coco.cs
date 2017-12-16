using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Coco : MonoBehaviour {
	public PlantaCoco enemyshoot;

	// Use this for initialization
	void Awake() {
		enemyshoot = gameObject.GetComponentInParent<PlantaCoco> ();
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			enemyshoot.Attack ();
		}
	}
}
