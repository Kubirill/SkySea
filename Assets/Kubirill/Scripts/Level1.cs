using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public buttonLevel1[] buttoms;
    public int[] correctNum;
    int step=0;
    public DoTweenActivate[] MovingObjects;
    //public Transform targetLattice;
    //public float speedLattice =0.5f;
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
            Debug.Log("Sendcorrect");
            if (step < correctNum.Length-1)
            {
                step++;
                
            }
            else
            {
                foreach (DoTweenActivate obj in MovingObjects)
                {
                   if (obj!=null) obj.GoToEnd();
                }
                GameObject.FindGameObjectWithTag("Dragon").GetComponent<DragonMove>().anim.SetTrigger("CatsSave");
            }

        }
        else
        {
            step = 0;
            foreach (buttonLevel1 buttom in buttoms)
            {

                buttom.SetMaterial("wrong");
            }
        }
    }
    // Update is called once per frame
    public void Releese()
    {
        if (step == 0)
        {
            foreach (buttonLevel1 buttom in buttoms)
            {

                buttom.SetMaterial("unactive");
            }
        }

    }
}
