﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public enum FieldType
{
	selfhand,
	selffield,
	enemyhand,
	enemyfield
		
}

public class DropPlayScript : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{

	public FieldType FieldType;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnDrop(PointerEventData eventData)
	{
		
		if (this.FieldType == FieldType.enemyfield || this.FieldType == FieldType.enemyhand)
		{
			return;
		}
        

		CardMovementScript cardMovementScript = eventData.pointerDrag.GetComponent<CardMovementScript>();
        if (cardMovementScript.gameManager.PlayerFieldCards.Count > 5)
        {
            return;
        }


		if (!GameManager.GetInstance().IsPlayerTurn)
		{
			return;
		}

		CardInfoScript cardInfoScript = cardMovementScript.GetComponent<CardInfoScript>();
		
		if (GameManager.GetInstance().PlayerMana < cardInfoScript.selfCard.manacost)
		{
			return;
		}

		if (cardMovementScript)
		{
			GameManager.GetInstance()
				.ReduceMana(true, cardInfoScript.selfCard.manacost);
			
            cardMovementScript.gameManager.PlayerFieldCards.Add(cardInfoScript);
            cardMovementScript.gameManager.PlayerHandCards.Remove(cardInfoScript);
			cardMovementScript.DefaultParent = transform;

			
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{

		if (this.FieldType == FieldType.enemyfield || this.FieldType == FieldType.enemyhand||this.FieldType==FieldType.selfhand)
		{
			return;
		}
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
