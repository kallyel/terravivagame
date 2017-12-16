using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public int over;
	// Use this for initialization
	void Start () {
		over = 5;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit") && over == 5) {
			SceneManager.LoadScene("nivel1");
		}
	}
}