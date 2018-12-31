using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoScript : MonoBehaviour
{

	public CardManager.Card selfCard;
	public Image logo;
	public TextMeshProUGUI name;

    public TextMeshProUGUI deadlinessLabel;
    public TextMeshProUGUI difficultyLabel;
    public Image hideObj;
    public GameObject highlightedObj;

    public void HideCardInfo(CardManager.Card c)
    {
        this.selfCard = c;
        hideObj.enabled = true;
    }

	public void ShowCardInfo(CardManager.Card c)
	{
		this.selfCard = c;
		this.logo.sprite = c.logo;
		this.name.SetText(c.Name);
		this.logo.preserveAspect = true;
        RefreshCard();
       
	}

	private void Start()
	
	{
		CardManager.Card c = CardManager.getInstance().deck[transform.GetSiblingIndex()];
        this.selfCard = c;
		//ShowCardInfo(c);
		
	}

    internal void RefreshCard()
    {
        this.difficultyLabel.text = selfCard.difficulty.ToString();
        this.deadlinessLabel.text = selfCard.deadliness.ToString();
    }

    public void HighlightCard()
    {
        highlightedObj.SetActive(true);
    }

    public void DehightlightCard()
    {
        highlightedObj.SetActive(false);
    }
}
