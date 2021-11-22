using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] ValueOfCard = new int[53];
    int currentIndex = 0;

    void Start()
    {
        GetCardValues();
    }

    void GetCardValues()
    {
        int num = 0;
        
        for(int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            num = num % 13;
            if(num > 10 || num == 0)
            {
                num = 10;
            }
            ValueOfCard[i] = num++;
        }    
    }
    
    public void Shuffle()
    {
        for(int i = cardSprites.Length - 1;  i > 0; --i)
        {
            //random number
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = ValueOfCard[i];
            ValueOfCard[i] = ValueOfCard[j];
            ValueOfCard[j] = value;
        }
        currentIndex = 1; 
    }

    public int DealCard(CardScript cardScript)
    {
        cardScript.setSprite(cardSprites[currentIndex]);
        cardScript.setValue(ValueOfCard[currentIndex]);
        currentIndex++;
        return cardScript.getValueOfCard();
    }

    public Sprite getCardBack()
    {
        return cardSprites[0];
    }
}
