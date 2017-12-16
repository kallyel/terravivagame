using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public Image imagem;
	private Animator animator;
	public int delay = 1;
	//
	// Use this for initialization
	void Start () {
		animator = imagem.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	 void Update () {
		if (Input.GetButtonDown ("Submit")) {
			animator.SetBool ("fade", true);
			StartCoroutine(Exemplo());

		}
	}
	IEnumerator Exemplo(){
		yield return new WaitForSeconds (delay);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
