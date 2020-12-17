using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinishZone : MonoBehaviour
{
    public DragonMove dragon;
    public Transform tformMother;
    public Transform target;
    MotherDragon[] scriptMother;
    public void Start()
    {
        scriptMother = tformMother.gameObject.GetComponentsInChildren<MotherDragon>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlotForCats")
        {
            foreach (MotherDragon scrtpt in scriptMother) scrtpt.OpenEyes();
            dragon.GetComponent<DragonMove>().target = target.gameObject;
            dragon.GetComponent<DragonMove>().player = tformMother;
            dragon.GetComponentInParent<Animator>().SetTrigger("FindMother") ;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlotForCats")
        {
            tformMother.LookAt(dragon.gameObject.transform);
        }
    }
}
