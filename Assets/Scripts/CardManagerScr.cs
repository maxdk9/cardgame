using DefaultNamespace;
using UnityEngine;


public class CardManagerScr : MonoBehaviour
{
    private void Awake()
    {
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.cerberus,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.chimera,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.minotaur,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.harpy,1,1));
            
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.colchiandragon,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.hydra,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.cyclops,1,1));
        CardManager.getInstance().deck.Add(new CardManager.Card(CardNames.nemeanlion,1,1));
    }
}