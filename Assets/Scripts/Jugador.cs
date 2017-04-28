using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {
	//Propiedades privadas
	private Rigidbody2D cuerpoRigido;
	private int _direccion = 1;
	private int _puntos = 0;
	private bool _esInvencible = false;
	private bool _pausa = false;

	//Propiedades serializables
	public Vector2 objetivoVelocidad;
	public Text puntuacion;

	//Get y set
	public bool esInvencible {
		get { return this._esInvencible; }
		set { this._esInvencible = value; }
	}

	public int direccion {
		get { return this._direccion; }
		set { this._direccion = value; }
	}

	public int puntos {
		get { return this._puntos; }
		set {
			this._puntos = value;
			this.puntuacion.text = "" + value;
			GeneradorEspinas.numeroEspinas += (value % 10 == 0 && value / 10 < 4) ? 1 : 0;
		}
	}

	public bool enPausa {
		get { return this._pausa; }
		set { 
			this._pausa = value;
			Time.timeScale = this._pausa ? 0 : 1;
		}
	}

	//Metodos Unity
	void Awake () {
		this.cuerpoRigido = this.GetComponent<Rigidbody2D> ();
	}

	void OnEnable() {
		Superficie.OnClick += OnClick;
	}

	void OnDisable() {
		Superficie.OnClick -= OnClick;
	}

	void FixedUpdate () {
		if (!enPausa) {
			this.ActualizarVelocidad (this.objetivoVelocidad.x * this._direccion, null);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag ("Lateral")) {
			this.direccion *= -1;
			this.puntos += 1;
		}
	}

	//Metodos
	public void OnClick() {
		if (!this.enPausa) {
			this.ActualizarVelocidad (null, this.objetivoVelocidad.y);
		}
	}

	public void OnPausa() {
		this.enPausa = !this.enPausa;
	}
		
	private void ActualizarVelocidad(float? x, float? y) {
		Vector2 velocidad = new Vector2 (this.cuerpoRigido.velocity.x, this.cuerpoRigido.velocity.y);
		if (x != null) velocidad.x = (float)x;
		if (y != null) velocidad.y = (float)y;

		this.cuerpoRigido.velocity = velocidad;
	}
}
