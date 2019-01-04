using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
using Random = System.Random;

public class GameManager : MonoBehaviour
{


    private static GameManager instance;
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }

    private Game CurrentGame;
    public Transform PlayerHand;
    public Transform EnemyHand;

    public Transform PlayerField;
    public Transform EnemyField;

    public TextMeshProUGUI playerManaLabel;
    public TextMeshProUGUI enemyManaLabel;


    public int PlayerMana=10;

    public int EnemyMana=10;

    internal void CardFight(CardInfoScript attackedCard, CardInfoScript attackingCard)
    {
        attackedCard.selfCard.GetDamage(attackingCard.selfCard.deadliness);
        attackingCard.selfCard.GetDamage(attackedCard.selfCard.deadliness);

        if (!attackedCard.selfCard.isAlive())
        {
            DestroyCard(attackedCard);
        }
        else
        {
            attackedCard.RefreshCard();
        }

        if (!attackingCard.selfCard.isAlive())
        {
            DestroyCard(attackingCard);
        }
        else
        {
            attackingCard.RefreshCard();
        }
    }

    private void DestroyCard(CardInfoScript card)
    {

        card.GetComponent<CardMovementScript>().OnEndDrag(null);

        if (PlayerFieldCards.Exists(x => x == card))
        {
            PlayerFieldCards.Remove(card);
        }
        if (EnemyFieldCards.Exists(x => x == card))
        {
            EnemyFieldCards.Remove(card);
        }
        
        Destroy(card.gameObject);
         

    }

    public GameObject CardPrefab;

    private int Turn, TurnTime = 30;
    public TextMeshProUGUI turnTimeTXT;
    public Button EndTurnButton;

    public List<CardInfoScript> PlayerHandCards = new List<CardInfoScript>();
    public List<CardInfoScript> PlayerFieldCards = new List<CardInfoScript>();
    public List<CardInfoScript> EnemyHandCards = new List<CardInfoScript>();
    public List<CardInfoScript> EnemyFieldCards = new List<CardInfoScript>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Turn = 0;
        CurrentGame = new Game();
        GiveHandCards(CurrentGame.playerDeck, PlayerHand);
        GiveHandCards(CurrentGame.enemyDeck, EnemyHand);
        this.EnemyMana = 10;
        this.PlayerMana = 10;
        UpdateManaLabels();
        StartCoroutine(TurnFunc());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TurnFunc()
    {
       TurnTime = 30;
        turnTimeTXT.text = TurnTime.ToString();
        foreach(var card in PlayerFieldCards)
        {
            card.DehightlightCard();
        }

        
        if (IsPlayerTurn)
        {
            foreach (var card in PlayerFieldCards)
            {
                card.selfCard.ChangeCanAttack(true);
                card.HighlightCard();
            }
            while (TurnTime-- > 0)
            {
                turnTimeTXT.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            foreach(var card in EnemyFieldCards)
            {
                card.selfCard.ChangeCanAttack(true);
            }

            while (TurnTime-- > 27)
            {
                turnTimeTXT.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }

            if (EnemyHandCards.Count > 0)
            {
                EnemyTurn(EnemyHandCards);
            }
        }
        ChangeTurn();
    }

    void GiveHandCards(List<CardManager.Card> list,Transform hand)
    {
        for (int i = 0; i < 4; i++) {
            GiveCardToHand(list, hand);
            }
    }

    private void GiveCardToHand(List<CardManager.Card> list, Transform hand)
    {

        if (list.Count == 0)
        {
            return;
        }

        CardManager.Card tekcard = list[0];
        GameObject cardGO = Instantiate(CardPrefab, hand, false);
        if (hand == EnemyHand)
        {
            cardGO.GetComponent<CardInfoScript>().HideCardInfo(tekcard);
            this.EnemyHandCards.Add(cardGO.GetComponent<CardInfoScript>());

        }
        if (hand == PlayerHand)
        {
            cardGO.GetComponent<CardInfoScript>().ShowCardInfo(tekcard,true);
            this.PlayerHandCards.Add(cardGO.GetComponent<CardInfoScript>());

        }
        list.RemoveAt(0);

    }

    public void ChangeTurn()
    {
        StopAllCoroutines();

        Turn++;
        EndTurnButton.enabled = (IsPlayerTurn);

        if (IsPlayerTurn)
        {
            GiveNewCards();
            PlayerMana = 10;
            EnemyMana = 10;
            UpdateManaLabels();
        }
        StartCoroutine(TurnFunc());
    }

    private void UpdateManaLabels()
    {
        this.enemyManaLabel.text = this.EnemyMana.ToString();
        this.playerManaLabel.text = this.PlayerMana.ToString();
    }


    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0;
        }
    }
    private void GiveNewCards()
    {


        GiveCardToHand(CurrentGame.playerDeck, PlayerHand);
        GiveCardToHand(CurrentGame.enemyDeck, EnemyHand);
    }


    public void EnemyTurn(List<CardInfoScript> enemyList)
    {

        if (EnemyFieldCards.Count > 5)
        {
            return;
        }
        int playedCardsNumber = UnityEngine.Random.Range(1, enemyList.Count);
        
        CardInfoScript card = enemyList[0];
        card.transform.SetParent(EnemyField);
        card.ShowCardInfo(card.selfCard,false);

        EnemyHandCards.Remove(card);
        EnemyFieldCards.Add(card);


        foreach (var activeCard in EnemyFieldCards.FindAll(x=>x.selfCard.canAttack))
        {
            if (PlayerFieldCards.Count == 0)
            {
                return;
            }

            var enemyCard = PlayerFieldCards[UnityEngine.Random.Range(0, PlayerFieldCards.Count-1)];

            String attackComment = "Ai card " + activeCard.selfCard.Name + " params : difficulty " +
                                   activeCard.selfCard.difficulty + ", deadliness " + activeCard.selfCard.deadliness +
                                   "attack player card " + enemyCard.selfCard.Name + " params : difficulty " +
                                   enemyCard.selfCard.difficulty + ", deadliness " + enemyCard.selfCard.deadliness;

            Debug.Log(attackComment);

            activeCard.selfCard.ChangeCanAttack(false);
            CardFight(enemyCard,activeCard);

        }

    }

    public void ReduceMana(bool isplayer, int manacost)
    {
        if (isplayer)
        {
            PlayerMana -= manacost;
        }
        else
        {
            EnemyMana -= manacost;
        }
        UpdateManaLabels();
    }
}
