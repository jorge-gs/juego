using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
	//Propiedades privadas
	private Rigidbody2D cuerpoRigido;

	private int direccion = 1;
    private int puntos=0;

	//Propiedades serializables
	public Vector2 objetivoVelocidad;

	void Awake () {
		this.cuerpoRigido = this.GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			this.ActualizarVelocidad (null, this.objetivoVelocidad.y);
		}
	}

	void FixedUpdate () {
		this.ActualizarVelocidad (this.objetivoVelocidad.x * this.direccion, null);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Lateral")) {
			this.direccion *= -1;
            this.puntos+=1;
		}
	}
		
	private void ActualizarVelocidad(float? x, float? y) {
		Vector2 velocidad = new Vector2 (this.cuerpoRigido.velocity.x, this.cuerpoRigido.velocity.y);
		if (x != null) velocidad.x = (float)x;
		if (y != null) velocidad.y = (float)y;

		this.cuerpoRigido.velocity = velocidad;
	}
}
