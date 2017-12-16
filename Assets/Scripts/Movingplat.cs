using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplat : MonoBehaviour {

	public int dirPlat;
	public int framecounti;
	int frameCount = 0;
	public float velo;

	void Start(){
		
	}


	void Update ()
	{

		frameCount++;  

		if (frameCount == framecounti)
		{
			frameCount = 0;

			if (dirPlat == 0)
				dirPlat = 1;
			else
				dirPlat = 0;
		}



		if (dirPlat == 0)
		{
			transform.Translate(Vector3.up * velo);
		}

		if (dirPlat  == 1)
		{
			transform.Translate(Vector3.down * velo);
		}

	}
}