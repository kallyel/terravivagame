using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour {
	public Image Primeira;
	public Image Segunda;
	public Image Terceira;
	bool isRunning = false;
	float oldTimer;
	public float delay = 1f;
	private string fullText = "Em um pequeno povoado de nome Trangola, próximo a cidade de Lagoa Nova - Rio Grande do Norte, " +
		"encontrava-se um garoto chamado Francisco."+ "\n" + "Certo dia, esse curioso garoto decide vasculhar as coisas antigas de seu tio X, " +
		"em busca de encontrar algo interessante para sair do tédio, lá, ele encontra uma antiga máquina, e não hesita em pressionar seus botões."
		+ "O que ele não sabia, é que era uma máquina do tempo, e agora já é tarde demais."+ "\n" +"\n"+ "        Ele se foi. ";

	private string currentText = "";

	public float texto2timer = 50;
	public Text textoprox;

	// Use this for initialization
	void Start () {
		oldTimer = texto2timer;
		StartCoroutine(ShowText());
		isRunning = true;
		textoprox.enabled = false;
		Primeira.enabled = false;
		Segunda.enabled = false;
	}
			
	IEnumerator ShowText(){
		for (int i = 0; i < fullText.Length; i++) {
			currentText = fullText.Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			yield return new WaitForSeconds (delay);
		}
	}
		

		void Update(){
		if (isRunning == true) {
			texto2timer -= Time.fixedDeltaTime;

		}
			
		if (texto2timer < 3) {
			textoprox.enabled = true;
			if (Input.GetButtonDown ("Submit")) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
			}

		if (texto2timer < 35) {
			Primeira.enabled = true;

		}
		if (texto2timer < 20) {
			Primeira.enabled = false;
			Segunda.enabled = true;

		}
		}




	}
	

