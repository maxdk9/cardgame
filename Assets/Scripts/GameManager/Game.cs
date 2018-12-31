using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public List<CardManager.Card> playerDeck;
    
    public List<CardManager.Card> enemyDeck;
    


    public Game()
    {
        playerDeck = GetDeckCard();
        
        enemyDeck = GetDeckCard();
       
    }
    public List<CardManager.Card> GetDeckCard()
    {
        List<CardManager.Card> result = new List<CardManager.Card>();
        for (int i = 0; i < 10; i++)
        {

            int cardnumber = Random.Range(0, CardManager.getInstance().deck.Count);
            CardManager.Card tekcard = CardManager.getInstance().deck[cardnumber];
            result.Add(tekcard);
        }
        return result;
    }
}
