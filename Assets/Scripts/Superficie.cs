using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Superficie : MonoBehaviour, IPointerClickHandler {
	public static event Click OnClick;
	public delegate void Click();

	void IPointerClickHandler.OnPointerClick (PointerEventData eventData)
	{
		if (OnClick != null) {
			OnClick ();
		}
	}
}
