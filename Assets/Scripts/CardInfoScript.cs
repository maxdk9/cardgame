using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CardInfoScript : MonoBehaviour
{

	public CardManager.Card card;
	public Image logo;
	public TextMeshProUGUI name;

	public void ShowCardInfo(CardManager.Card c)
	{
		this.card = c;
		this.logo.sprite = c.logo;
		this.name.SetText(c.Name);
		this.logo.preserveAspect = true;
	}

	private void Start()
	
	{
		CardManager.Card c = CardManager.getInstance().deck[transform.GetSiblingIndex()];
		
		ShowCardInfo(c);
		
	}
}
