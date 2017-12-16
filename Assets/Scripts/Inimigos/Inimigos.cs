using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour {
	public float velocidade;
	public bool direcao;
	public float duracaoDirecao;


	private float tempoNaDirecao;
	private Animator animator;
	public Transform inimigo;


	// Use this for initialization
	void Start () {
		animator = inimigo.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (direcao) {
			transform.eulerAngles = new Vector2(0, 180);
		} else {
			transform.eulerAngles = new Vector2(0, 0);
		}
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);

		tempoNaDirecao += Time.deltaTime;
		if (tempoNaDirecao >= duracaoDirecao) {
			tempoNaDirecao = 0;
			direcao = !direcao;
	}
	}
}
