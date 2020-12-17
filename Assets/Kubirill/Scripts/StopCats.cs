using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCats : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Cats>() != null) other.GetComponentInParent<Cats>().StopCats();
    }
}
