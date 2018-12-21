using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlayScript : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnDrop(PointerEventData eventData)
	{
		CardMovementScript cardMovementScript = eventData.pointerDrag.GetComponent<CardMovementScript>();
		if (cardMovementScript)
		{
			cardMovementScript.DefaultParent = transform;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (eventData.pointerDrag == null)
		{
			return;
		}

		CardMovementScript cardMovementScript = eventData.pointerDrag.GetComponent<CardMovementScript>();
		if (cardMovementScript)
		{
			cardMovementScript.DefaultTempCardParent = transform;
		}
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (eventData.pointerDrag == null)
		{
			return;
		}
		
		CardMovementScript cardMovementScript = eventData.pointerDrag.GetComponent<CardMovementScript>();
		if (cardMovementScript&&cardMovementScript.DefaultTempCardParent==transform)
		{
			cardMovementScript.DefaultTempCardParent = cardMovementScript.DefaultParent;
		}
	}
}
