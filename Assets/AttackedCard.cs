using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedCard : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardInfoScript card = eventData.pointerDrag.GetComponent<CardInfoScript>();
        
        if (card && card && card.selfCard.canAttack && transform.parent == GameManager.GetInstance().EnemyField)
        {
            card.selfCard.ChangeCanAttack(false);
            CardInfoScript attackedCard = this.GetComponent<CardInfoScript>();
            GameManager.GetInstance().CardFight(card, attackedCard);
        }
    }

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
