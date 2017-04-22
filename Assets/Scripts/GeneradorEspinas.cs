using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEspinas : MonoBehaviour {
	public static int numeroEspinas = 3;

	//Propiedades privadas
	private List<GameObject> espinas = new List<GameObject> ();

	//Propiedades serializables
	public GeneradorEspinas lateralOpuesto;
	public GameObject prefabEspina;
	public Jugador jugador;
	public int direccion;

	void OnCollisionEnter2D(Collision2D collision) {
		foreach (GameObject espina in this.espinas) {
			Destroy (espina);
		}
		this.espinas.Clear ();

		this.GenerarEspinas ();
	}

	private void GenerarEspinas () {
		//i es el numero de espinas generadas
		int i = 0;
		//j es el numero de puestos
		for (int j = 0; j < 10; j++) {
			int puestosRestantes = 10 - j;
			int espinasRestantes = GeneradorEspinas.numeroEspinas - i;
			if (puestosRestantes <= espinasRestantes || Random.value >= 0.5) {
				GameObject espina = Instantiate (prefabEspina);//GameObject.CreatePrimitive (PrimitiveType.Cube);
				espina.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
				espina.transform.position = new Vector3 (this.lateralOpuesto.transform.position.x + (this.direccion * 0.75f), -4.5f + j);
				espina.transform.parent = this.lateralOpuesto.transform;

				this.lateralOpuesto.espinas.Add (espina);
				i++;

				if (i == GeneradorEspinas.numeroEspinas) {
					break;
				}
			}
		}
	}
}
