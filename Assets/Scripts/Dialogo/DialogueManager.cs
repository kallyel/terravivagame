using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public Text nameText;
	public Text dialogueText;
	public GameObject bt1;
	public GameObject bt2;
	public Image F;
	public Image M;
	public Image Fb;
	public Image Mb;

		

	private Queue<string> sentences;
	void Start () {
		bt2.SetActive (false);
		M.enabled = false;
		F.enabled = false;
		Mb.enabled = false;
		Fb.enabled = false;

		sentences = new Queue<string> ();

	}

	public void StartDialogue(Dialogue dialogue){
		bt1.SetActive (false);
		bt2.SetActive (true);
		sentences.Clear ();
		foreach (string sentence in dialogue.sentences) {
			
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence();

	}

	public void DisplayNextSentence(){
		
		if (sentences.Count % 2 == 0) {
			nameText.text = "Francisco";
			M.enabled = false;
			F.enabled = true;
			Mb.enabled = false;
			Fb.enabled = true;
		} if (sentences.Count % 2 != 0 && sentences.Count < 22) {
			nameText.text = "Melocactu";
			F.enabled = false;
			M.enabled = true;
			Fb.enabled = false;
			Mb.enabled = true;

		} 
		if (sentences.Count == 1) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence){
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}


}
