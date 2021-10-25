using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // I will use this Code for the players  as well for the dealer 2
    // keeps track of cards

    public CardScript cardScript;
    public DeckScript deckScript;

    public int handValue = 0;
    private int money = 50;

    //the cards on the table
    public GameObject[] hand;
    public int cardIndex = 0;

    //tracking if ace will be 1 or 11
    List<CardScript> aceList = new List<CardScript>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // dealing ot the cards
    public int GetCard()
    {
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());

        //showing the cards
        hand[cardIndex].GetComponent<Renderer>().enabled = true;

        handValue += cardValue;
        if(cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        
        //AceCheck();
        cardIndex++;

        return handValue;
    }
}
