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
    
    void Start()
    {
        //click listeners to the buttons:
        dealButton.onClick.AddListener( ()=> DealClicked() );
        hitButton.onClick.AddListener( ()=> HitClicked() );
        standButton.onClick.AddListener( ()=> StandClicked() );
    }

    private void DealClicked()
    {
        
    }

    private void HitClicked()
    {
        
    }

    private void StandClicked()
    {
        
    }

}