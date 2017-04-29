using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeFinal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var mensaje = (Jugador.esMaxima ? "Nueva puntuación máxima!\n" : "") +
		              "Tu puntuación es: " + Jugador.ultimaPuntuacion;
		this.GetComponent<Text> ().text = mensaje;
	}
}
