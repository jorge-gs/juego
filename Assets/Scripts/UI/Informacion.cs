using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informacion : MonoBehaviour {
	public GameObject padre;
	public GameObject panel;

	public void OnClick() {
		this.panel.SetActive (true);
		this.panel.GetComponent<Animator> ().SetBool ("Mostrar", true);

		this.padre.SetActive (false);
	}
}
