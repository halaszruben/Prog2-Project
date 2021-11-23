using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    public AudioSource[] track;

    public int trackSelect;
    public int trackHistory;

    void Start()
    {
        trackSelect = Random.Range(0, 3);
        
        if(trackSelect == 0)
        {
            track[0].Play();
            trackHistory = 1;
        }
        else if (trackSelect == 1)
        {
            track[1].Play();
            trackHistory = 2;
        }
        else if (trackSelect == 2)
        {
            track[2].Play();
            trackHistory = 3;
        }
    }

    void Update()
    {
        if(track[0].isPlaying == false && track[1].isPlaying == false && track[2].isPlaying == false)
        {
            trackSelect = Random.Range(0, 3);
        
        if(trackSelect == 0 && trackHistory != 1)
        {
            track[0].Play();
            trackHistory = 1;
        }
        else if (trackSelect == 1 && trackHistory != 2)
        {
            track[1].Play();
            trackHistory = 2;
        }
        else if (trackSelect == 2 && trackHistory != 3)
        {
            track[2].Play();
            trackHistory = 3;
        }
        }
    }

}
