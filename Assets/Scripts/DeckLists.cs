using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckLists : MonoBehaviour {
    public GameObject deck_panel;
    public List<GameObject> deck_list = new List<GameObject>();

    void Start() //pulls a decklist from the deck lists saved between scenes
    {
        deck_list = GlobalControl.Instance.deck_list;
    }

    public void SaveDeck() //saves the deck list as the global deck list(which is shared between scenes)
    {
        GlobalControl.Instance.deck_list = deck_list;
    }

    public void returnToMenu() //checks the deck for the proper amount of cards, and saves the deck
    {
        Card[] deck = deck_panel.GetComponentsInChildren<Card>();//obtains the cards from the panel 
        if (deck.Length == 20) //checks if deck length is appropriate
        {
            GlobalControl.Instance.deck_list.Clear(); //clears the global deck list
            foreach (Card card in deck) //adds each card from the deck to the deck lists
            {
                deck_list.Add(card.gameObject);
            }
        }
        SaveDeck(); //saves the deck that was just created by the user
    }
}
