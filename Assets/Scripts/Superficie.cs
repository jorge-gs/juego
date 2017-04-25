using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superficie : MonoBehaviour {
	public static event Click OnClick;
	public delegate void Click();

	void OnMouseDown() {
		if (OnClick != null) {
			OnClick ();
		}
	}
}
