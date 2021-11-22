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
    public Text mainText;

    public GameObject hideCard;

    int jackPot = 0;

    void Start()
    {
        //click listeners to the buttons:
        dealButton.onClick.AddListener( ()=> DealClicked() );
        hitButton.onClick.AddListener( ()=> HitClicked() );
        standButton.onClick.AddListener( ()=> StandClicked() );
        betButton.onClick.AddListener( ()=> BetClicked() );
    }

    private void DealClicked()
    {
        playerScript.ResetHand();
        dealerScript.ResetHand();

        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);

        GameObject.Find("Deck/Table").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();

        scoreText.text = "Hand: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Dealer hand: " + dealerScript.handValue.ToString();

        //one of the dealers card visibility
        hideCard.GetComponent<Renderer>().enabled = true;

        //visibility to buttons same with the text
        dealButton.gameObject.SetActive(false);
        hitButton.gameObject.SetActive(true);
        standButton.gameObject.SetActive(true);

        standButtonText.text = "Stand";

        //the standard bet at every round
        jackPot = 2;
        betText.text = "Bet: " + jackPot.ToString() + "$";
        playerScript.AdjustMoney(-2);
        moneyText.text = playerScript.GetMoney().ToString() + "$";

    }

    private void HitClicked()
    {
        if (playerScript.cardIndex < 11)
        {
            playerScript.GetCard();

            scoreText.text = "Hand: " + playerScript.handValue.ToString();

            if(playerScript.handValue > 20)
                RoundOver();
        }
    }

    //some rules:
    //if it's clicked and the dealer's hand is 16 or under, then the dealer must take a cards until reaches 17 or more
    //if the dealer reached 17 or more the turn/hand is over
    private void StandClicked()
    {
        standClicked++;
        if(standClicked > 1)
            RoundOver();
        HitDealer();
        standButtonText.text = "Call";   
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();

            dealerScoreText.text = "Dealer hand: " + dealerScript.handValue.ToString();

            if(dealerScript.handValue > 20)
                RoundOver();
        }
    }

    void RoundOver()
    {
        //checking the scores
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = playerScript.handValue == 21;

        //if there are no winners or busts and the stand has not been clicked twice quit the function
        if(standClicked < 2 && !playerBust && !dealerBust && !player21 && !dealer21)
            return;

        bool roundOver = true;
        //rule
        //if both of them busts, we return the money and also we check every situation from here on
        if(playerBust && dealerBust)
        {
            mainText.text = "All Bust, bets returned!";
            playerScript.AdjustMoney(jackPot/2);
        }
        else if(playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer won!";
        }
        else if(dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = "You won!";
            playerScript.AdjustMoney(jackPot);
        }
        else if(playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Tie, bets returned!";
            playerScript.AdjustMoney(jackPot/2);
        }
        else
        {
            roundOver = false;
        }

        //setting up for next turn
        if(roundOver)
        {
            hitButton.gameObject.SetActive(false);
            standButton.gameObject.SetActive(false);
            dealButton.gameObject.SetActive(true);

            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);

            hideCard.GetComponent<Renderer>().enabled = false;
            moneyText.text = playerScript.GetMoney().ToString() + "$";
            standClicked = 0;
        }
    }

    void BetClicked()
    {
        //it gives me the actual text of the bet button and we set it to 'Text'
        Text newBet = betButton.GetComponentInChildren(typeof(Text)) as Text;
        //getting rid of the $ sign
        int intBet = int.Parse(newBet.text.ToString().Remove(1, 1));

        if(jackPot == 2)
            jackPot = 4;

        playerScript.AdjustMoney(-intBet);
        moneyText.text = playerScript.GetMoney().ToString() + "$";
        jackPot += (intBet * 2);
        betText.text = "Bet: " + (jackPot / 2).ToString() + "$";
    }

}
