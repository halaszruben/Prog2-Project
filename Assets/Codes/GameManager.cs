using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //The game buttons:
    public Button dealButton;
    public Button hitButton;
    public Button standButton;
    public Button betButton;
    
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    private int standClicked = 0;

    void Start()
    {
        //click listeners to the buttons:
        dealButton.onClick.AddListener( ()=> DealClicked() );
        hitButton.onClick.AddListener( ()=> HitClicked() );
        standButton.onClick.AddListener( ()=> StandClicked() );
    }

    private void DealClicked()
    {
        GameObject.Find("Deck/Table").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
    }

    private void HitClicked()
    {
        if (playerScript.GetCard() < 11)
        {
            playerScript.GetCard();
        }
    }

    //some rules:
    //if it's clicked and the dealer's hand is 16 or under, then the dealer must take a cards until reaches 17 or more
    //if the dealer reached 17 or more the turn/hand is over
    private void StandClicked()
    {
        
    }

}
