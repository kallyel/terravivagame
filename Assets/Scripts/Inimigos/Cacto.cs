using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacto : MonoBehaviour {
	public int curhealth;
	public int maxhealth;
	public float distancia;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;


	public GameObject bullet;
	public GameObject bulletup;

	public Transform target;
	public Transform shootpoint2;
	public Transform shootpoint6;
	public Transform shootpoint8;

	public Animator anim;



	// Use this for initialization
	void Start () {
		curhealth = maxhealth;

		anim = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
		

	public void Attack(){
		bulletTimer += Time.deltaTime;


		if (bulletTimer >= shootInterval) {
			


			Vector2 direction = Vector2.left;


			Vector2 direction2 = Vector2.right;
			direction2.Normalize ();

			Vector2 direction3 = Vector2.up;
			direction3.Normalize ();



			GameObject bulletCloneE;
			GameObject bulletCloneD;
			GameObject bulletCloneU;

			bulletCloneE = Instantiate (bullet, shootpoint2.transform.position, shootpoint2.transform.rotation) as GameObject;
			bulletCloneE.transform.eulerAngles = new Vector2(180, 0 );
			bulletCloneE.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;


		
			bulletCloneD = Instantiate (bullet, shootpoint6.transform.position, shootpoint6.transform.rotation) as GameObject;
			bulletCloneD.GetComponent<Rigidbody2D> ().velocity = direction2 * bulletSpeed;


			bulletCloneU = Instantiate (bulletup, shootpoint8.transform.position, shootpoint8.transform.rotation) as GameObject;
			bulletCloneU.GetComponent<Rigidbody2D> ().velocity = direction3 * bulletSpeed;
			bulletCloneU.transform.eulerAngles = new Vector3(0, 0, 270 );

			bulletTimer = 0;
			Object.Destroy(bulletCloneD, 5.0f);
			Object.Destroy(bulletCloneE, 5.0f);
			Object.Destroy(bulletCloneU, 5.0f);
		}
	}
}















