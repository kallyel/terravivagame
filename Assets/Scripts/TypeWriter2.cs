using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter2 : MonoBehaviour {
	bool isRunning = false;
	float oldTimer;
	public float delay = 1f;
	private string fullText = "Francisco agora encontra-se em um lugar distante, perdido, sem ninguém para ajudá-lo. " +"\n"+
		"É ai que você entra, acha que consegue ajudar Francisco a voltar para casa? Aperte o cinto e embarque nessa aventura! ";
	private string currentText = "";

	public float texto2timer = 10;

	public Text textoprox;


	// Use this for initialization
	void Start () {
		oldTimer = texto2timer;
		StartCoroutine(ShowText());
		isRunning = true;
		textoprox.enabled = false;
	}

	IEnumerator ShowText(){
		for (int i = 0; i < fullText.Length; i++) {
			currentText = fullText.Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			yield return new WaitForSeconds (delay);
			if (i == fullText.Length) {
				fullText = "";
				currentText = "";
				StartCoroutine(ShowText());
			}
		}
	}
		

	void Update(){
		if (isRunning == true) {
			texto2timer -= Time.fixedDeltaTime;

		}
		if (texto2timer < 9) {
			textoprox.enabled = true;
			if (Input.GetButtonDown ("Submit")) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
		}

	}

}
