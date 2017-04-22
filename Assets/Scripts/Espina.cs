using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Espina : MonoBehaviour {
	public Collider2D colisionador;

	void Awake() {
		this.colisionador = this.GetComponent<Collider2D>();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Jugador")) {
			SceneManager.LoadScene ("Principal");
		}
	}

   public  void Desaparecer()
    {
        Debug.Log("Desaparecer");
        var animador = this.gameObject.GetComponentInParent <Animator>();
        animador.SetBool("activo", false);
        Destroy(this, 0.5f);
    }

    private void Eliminar()
    {
      
    }
}
