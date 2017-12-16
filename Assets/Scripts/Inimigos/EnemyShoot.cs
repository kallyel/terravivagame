using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
	public int curhealth;
	public int maxhealth;
	public float distancia;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;
	public bool acordado = false;

	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform shootpoint;

	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		curhealth = maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Acord", acordado);
		RangeCheck ();
		
	}

	void RangeCheck(){
		distancia = Vector3.Distance (transform.position, target.transform.position);
		if (distancia < wakeRange) {
			acordado = true;
		}
		if (distancia > wakeRange) {
			acordado = false;
		}
	}

	public void Attack(){
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();
		

		
			GameObject bulletClone;
			bulletClone = Instantiate (bullet, shootpoint.transform.position, shootpoint.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			bulletTimer = 0;
		}
	}
}















