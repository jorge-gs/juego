using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEspinas : MonoBehaviour {
	//Propiedades privadas
	private List<GameObject> espinas = new List<GameObject> ();

	//Propiedades serializables
	public GeneradorEspinas lateralOpuesto;
	public int direccion;

	void OnCollisionEnter2D(Collision2D collision) {
		foreach (GameObject espina in this.espinas) {
			Destroy (espina);
		}
		this.espinas.Clear ();

		for (int i = 0; i < 10; i++) {
			GameObject espina = GameObject.CreatePrimitive (PrimitiveType.Cube);
			espina.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			espina.transform.position = new Vector3 (this.lateralOpuesto.transform.position.x + (this.direccion * 0.75f), -4.5f + i);

			espina.transform.parent = this.lateralOpuesto.transform;

			this.lateralOpuesto.espinas.Add (espina);
		}
	}
}
