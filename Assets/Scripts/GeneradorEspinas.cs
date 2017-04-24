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
		foreach (GameObject contenedor in this.espinas) {
            var animador = contenedor.gameObject.GetComponent<Animator>();
            animador.SetBool("estaActivo", false);

            Destroy(contenedor, 0.5f);
		}
		this.espinas.Clear ();

		this.GenerarEspinas ();
	}

	private void GenerarEspinas () {
		//i es el numero de espinas generadas
		int i = 0;
		//j es el numero de puestos
		for (int j = 0; j < 10; j++) {
			bool rotar = direccion == -1;
			int puestosRestantes = 10 - j;
			int espinasRestantes = GeneradorEspinas.numeroEspinas - i;
            if (puestosRestantes <= espinasRestantes || Random.value >= 0.5)
            {
				GameObject espina = Instantiate (prefabEspina);//GameObject.CreatePrimitive (PrimitiveType.Cube);
				espina.transform.localScale = new Vector3 (1f, 1f, 1f);
				espina.transform.position = new Vector3 (this.lateralOpuesto.transform.position.x + (this.direccion * 0.25f), -4.5f + j, -1);
				espina.transform.rotation = Quaternion.Euler (new Vector3 (0, rotar ? 180 : 0)); 
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
