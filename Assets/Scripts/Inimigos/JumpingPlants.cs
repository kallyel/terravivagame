using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlants : MonoBehaviour {
	private bool grounded;
	public float groundCheckRadius;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	void Start () {
		
	}

	void Update () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (GameObject.Find ("jumplant") && grounded) {
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 900);
		}
	}
}
