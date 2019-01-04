using DefaultNamespace;
using UnityEngine;


public class CardManagerScr : MonoBehaviour
{
    private void Awake()
    {
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.cerberus,3,1,2));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.chimera,2,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.minotaur,3,2,2));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.harpy,2,1,1));
            
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.colchiandragon,6,2,3));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.hydra,5,1,2));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.cyclops,3,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.nemeanlion,4,2,2));
    }
}