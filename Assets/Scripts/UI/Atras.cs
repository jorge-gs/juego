using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atras : MonoBehaviour {
	public GameObject padre;
	public GameObject panel;

	public void OnClick() {
		this.padre.GetComponent<Animator> ().SetBool ("Mostrar", false);
		Invoke ("OnAnimacionTermino", 0.5f);
	}

	public void OnAnimacionTermino() {
		this.padre.SetActive (false);
		this.panel.SetActive (true);
	}
}
