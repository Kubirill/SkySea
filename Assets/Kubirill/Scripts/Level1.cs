﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public buttonLevel1[] buttoms;
    public int[] correctNum;
    int step=0;
    public Transform lattice;
    public Transform targetLattice;
    public float speedLattice =0.5f;
    void Start()
    {
        foreach (buttonLevel1 buttom in buttoms)
        {
            buttom.SetMain(GetComponent<Level1>());
        }
    }

    public void Press (int num)
    {
        if (correctNum[step]==num)
        {
            buttoms[num].SetMaterial("correct");
            if (step < correctNum.Length-1)
            {
                step++;
                
            }
            else
            {
                lattice.DOMove(targetLattice.position,speedLattice);
            }

        }
        else
        {
            step = 0;
            foreach (buttonLevel1 buttom in buttoms)
            {
                buttom.SetMaterial("unactive");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
