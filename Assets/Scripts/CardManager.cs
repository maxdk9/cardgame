using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


public class CardManager
    {
        private static CardManager _instance;
        public List<Card> deck;


        public static CardManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new CardManager();
            }

            return _instance;
        }


        public struct Card
        {
            public string Name;
            public Sprite logo;
            public int difficulty;
            public int deadliness;

            public Card(string name, int difficulty, int deadliness)
            {
                this.Name = name;
                this.difficulty = difficulty;
                this.deadliness = deadliness;

                String logopath = "Images/cards/" + name;
                

                this.logo = Resources.Load<Sprite>(logopath);
                if (this.logo == null)
                {
                    Debug.Log("No image for name "+name+" on path "+logopath);
                }
                
                
                
            }
        }

        public CardManager()
        {
            deck = new List<Card>();
        }
    }

   
