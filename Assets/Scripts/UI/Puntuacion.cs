using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var texto = this.gameObject.GetComponent<Text> ();
		texto.text = "" + PlayerPrefs.GetInt ("Puntuacion");
	}
}
