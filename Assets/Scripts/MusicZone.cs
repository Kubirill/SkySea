using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public MusicPlayList main;
    public int numMusicInPlayList;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlotForCats")
        {
            main.PlayNextSong(numMusicInPlayList);
        }
    }
}
