using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarLimites : MonoBehaviour {
	public GameObject inferiror;
	public GameObject superior;
	public GameObject izquierdo;
	public GameObject derecho;
	public Camera camara;

	// Use this for initialization
	void Start () {
		//Obtener dimensiones en pixeles
		int anchoPixeles = Screen.width;
		int altoPixeles = Screen.height;

		//Obtener dimensiones en puntos
		float razonPixelesPuntos = altoPixeles / (2 * this.camara.orthographicSize);
		float anchoPuntos = anchoPixeles / razonPixelesPuntos;
		float altoPuntos = anchoPixeles / razonPixelesPuntos;

		this.derecho.transform.position = new Vector3 ((anchoPuntos + 1) / 2, 0);
		this.izquierdo.transform.position = new Vector3 (-(anchoPuntos + 1) / 2, 0);

		this.superior.transform.localScale = new Vector3 (anchoPuntos, 1, 1);
		this.inferiror.transform.localScale = new Vector3 (anchoPuntos, 1, 1);

		Debug.Log (this.izquierdo.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
