using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour {
	public EnemyShoot enemyshoot;

	// Use this for initialization
	void Awake() {
		enemyshoot = gameObject.GetComponentInParent<EnemyShoot> ();
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			enemyshoot.Attack ();
		}
	}
}
