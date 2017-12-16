using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {
	public float delay = 1;
	private bool isRunning;

	void Start(){
		isRunning = true;
		Destroy (gameObject, delay);
	}
	void Update(){
		if (isRunning == true) {
			delay -= Time.fixedDeltaTime;
		}

		if (delay < 0) {
			Destroy (this.gameObject);
		}
	}
}
