using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitesVerticales : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Jugador")) {
			var jugador = collision.gameObject.GetComponent<Jugador> ();
			if (!jugador.esInvencible) {
				SceneManager.LoadScene ("Perder");
			}
		}
	}
}
