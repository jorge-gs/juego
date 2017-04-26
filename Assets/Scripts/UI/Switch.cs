using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Switch : MonoBehaviour {
	private Animator animador;
	private bool _seleccionado;

	public bool seleccionar;

	public bool seleccionado {
		get { return this._seleccionado; }
		set {
			this.animador.SetBool("Seleccionar", value);
			this._seleccionado = value;
		}
	}

	void Awake() {
		this._seleccionado = this.seleccionar;
		this.animador = this.GetComponent<Animator> ();
	}

	public void OnSeleccionar() {
		this.seleccionado = !this.seleccionado;
	}
}
