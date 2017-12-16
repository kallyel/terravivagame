using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	private Vector2 velocity;
	public float smoothtimeY;
	public float smoothtimeX;

	public GameObject target;
	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	void Start(){
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update ()
	{
		float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothtimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothtimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);
		if (bounds) {
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}

}
