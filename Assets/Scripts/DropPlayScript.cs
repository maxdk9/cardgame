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
		CardScript cardScript = eventData.pointerDrag.GetComponent<CardScript>();
		if (cardScript)
		{
			cardScript.DefaultParent = transform;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (eventData.pointerDrag == null)
		{
			return;
		}

		CardScript cardScript = eventData.pointerDrag.GetComponent<CardScript>();
		if (cardScript)
		{
			cardScript.DefaultTempCardParent = transform;
		}
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (eventData.pointerDrag == null)
		{
			return;
		}
		
		CardScript cardScript = eventData.pointerDrag.GetComponent<CardScript>();
		if (cardScript&&cardScript.DefaultTempCardParent==transform)
		{
			cardScript.DefaultTempCardParent = cardScript.DefaultParent;
		}
	}
}
