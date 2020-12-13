using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtomLevel2 : MonoBehaviour
{
    public Transform leftGoal;
    public Transform rightGoal;
    public Transform leftOpen;
    public Transform rightOpen;
    public Transform leftClose;
    public Transform rightClose;
    public float speed;
    bool stay=false;
    bool isOpen = false;
    Animator anim;
    public void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    public void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Dragon") || (other.tag == "barrel"))
        {
            stay = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Dragon") || (other.tag == "barrel"))
        {
            stay = false;
        }
    }
    public void LateUpdate()
    {
        if ((!stay)&&(isOpen))
        {
            anim.SetBool("Press", false);
            isOpen = false;
            leftGoal.DORotateQuaternion(leftClose.rotation, speed);
            rightGoal.DORotateQuaternion(rightClose.rotation, speed);
        }
        if ((stay) && (!isOpen))
        {
            anim.SetBool("Press", true);
            isOpen = true;
            leftGoal.DORotateQuaternion(leftOpen.rotation, speed);
            rightGoal.DORotateQuaternion(rightOpen.rotation, speed);
        }
    }
}
