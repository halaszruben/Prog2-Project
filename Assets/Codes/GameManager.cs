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

    public Text standButtonText;
    
    public Text scoreText;
    public Text dealerScoreText;
    public Text betText;
    public Text moneyText;
    //public Text mainText;

    public GameObject hideCard;

    int jackPot = 0;

    void Start()
    {
        //click listeners to the buttons:
        dealButton.onClick.AddListener( ()=> DealClicked() );
        hitButton.onClick.AddListener( ()=> HitClicked() );
        standButton.onClick.AddListener( ()=> StandClicked() );
    }

    private void DealClicked()
    {
        dealerScoreText.gameObject.SetActive(false);

        GameObject.Find("Deck/Table").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();

        scoreText.text = "Hand value: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Dealer hand: " + dealerScript.handValue.ToString();

        //visibility to buttons same with the text
        dealButton.gameObject.SetActive(false);
        hitButton.gameObject.SetActive(true);
        standButton.gameObject.SetActive(true);

        standButtonText.text = "Stand";

        //the standard bet at every round
        jackPot = 3;
        betText.text = jackPot.ToString();
        playerScript.AdjustMoney(-5);
        moneyText.text = playerScript.GetMoney().ToString();

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
        standClicked++;
        if(standClicked > 1)
            Debug.Log("End the function");
        HitDealer();
        standButtonText.text = "Call";   
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
        }
    }

}
