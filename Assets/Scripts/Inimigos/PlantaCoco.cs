using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaCoco : MonoBehaviour {
	public int curhealth;
	public int maxhealth;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;


	public GameObject bullet;

	public Transform target;
	public Transform shootpoint;
	public Transform shootpoint2;


	// Use this for initialization
	void Start () {
		curhealth = maxhealth;
	}

	// Update is called once per frame
	void Update () {


	}


	public void Attack(){
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {
			Vector2 direction = Vector2.down;

		



			GameObject bulletClone;
			bulletClone = Instantiate (bullet, shootpoint.transform.position, shootpoint.transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			bulletClone = Instantiate (bullet, shootpoint2.transform.position, shootpoint2.transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			bulletTimer = 0;
		}
	}



}














