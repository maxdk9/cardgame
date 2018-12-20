using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CardManager
    {
        private static CardManager _instance;
        public List<Card> deck;
        

        public static CardManager getInstance()
        {
            if (_instance == null)
            {
                _instance=new CardManager();
                
            }

            return _instance;
        }
        
        
        
        
        
        
        
        
        
        public struct Card
        {
            public string Name;
            public string Sprite;
                              public int difficulty;
                                                    public int deadliness;

            public Card(string name, string sprite, int difficulty, int deadliness)
            {
                this.Name = name;
                this.Sprite = sprite;
                this.difficulty = difficulty;
                this.deadliness = deadliness;
            }
        }

        public CardManager()
        {
            deck=new List<Card>();
        }
    }

    public class CardManagerScr : MonoBehaviour
    {
        private void Awake()
        {
            CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.argo));
            
        }
    }
    
}