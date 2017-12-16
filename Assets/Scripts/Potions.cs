using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour {
	public int npotions;
	public Text potionsText;
	public Text InputText;
	public int faltam;
	public GameObject door;

	void Start(){
		
	}
	void Update(){
		faltam = door.GetComponent<Door>().goalspt;
		potionsText.text = (npotions+ "/" + faltam);
}

}
