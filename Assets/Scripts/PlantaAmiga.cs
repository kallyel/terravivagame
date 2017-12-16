using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaAmiga : MonoBehaviour {
	public Transform target;
	public Transform Jogador;
	public float speed = 10f;
	private Transform myTransform;


	void Start () {
		myTransform = this.GetComponent<Transform>();
		Physics2D.IgnoreCollision(Jogador.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (1, -90, -1));	
		myTransform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

	}

		void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "Finish") {
			speed = 0;
		}
	}
	void OnTriggerExit2D(Collider2D obj){
			if(obj.gameObject.tag == "Finish"){
		speed = 10f;
			}
	}
}
