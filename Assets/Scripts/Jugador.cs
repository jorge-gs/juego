using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
	private float tiempo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tiempo > 5) {
			this.tiempo = (this.tiempo - 5) + Time.deltaTime;
		} else {
			this.tiempo += Time.deltaTime;
		}

		Vector3 posicion = 1.25f * new Vector3 (Mathf.Cos(2 * Mathf.PI / 5 * tiempo), Mathf.Sin(2 * Mathf.PI / 5 * tiempo));
		float angulo = Mathf.Atan2 (posicion.y, posicion.x);

		this.gameObject.GetComponent<Rigidbody2D> ().position = posicion;
		this.gameObject.transform.rotation = Quaternion.Euler(0, 0, angulo);

		Debug.Log (this.gameObject.transform.rotation);
	}
}
