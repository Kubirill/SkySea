using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag=="Solid") GetComponentInParent<Animator>().SetTrigger("CollizionInFront");

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Solid")
        {
            GetComponentInParent<Animator>().SetTrigger("CollizionInFront");
            transform.parent.position = transform.parent.position - transform.parent.forward*3;
        }

    }
}
