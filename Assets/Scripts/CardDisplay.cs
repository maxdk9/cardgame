using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

	public Card card;
	public  Text cardName;
	private Text cardDescription;
	private Text difficultyString;
	private Text deadlinessString;
	private Image cardPicture;
	
	// Use this for initialization
	void Start ()
	{
		cardName.text = card.name;
		cardDescription.text = card.GetDescription();
		difficultyString.text = card.GetCurrentDifficulty().ToString();
		deadlinessString.text = card.getCurrentDeadliness().ToString();
		cardPicture.sprite = card.Sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
