using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
   //it's kinda like a storage, i will store here informations about the cards
   public int value = 0;

   public int getValueOfCard()
   {
       return value;
   }

   public void setValue(int newValue)
   {
       value = newValue;
   }
   
   public string getSpriteName()
   {
        return GetComponent<SpriteRenderer>().sprite.name;
   }

   public void setSprite(Sprite newSprite)
   {
       gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
   }

   public void resetCard()
   {
        Sprite back = GameObject.Find("Deck/Table").GetComponent<DeckScript>().getCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
   } 



}
