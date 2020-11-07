using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Port : MonoBehaviour
{
    public GameObject ship;
    public Collider[] buttons;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ship.transform.DOMove(transform.parent.position, 4);
            ship.transform.DORotateQuaternion(transform.parent.rotation, 4);
            foreach (Collider button in buttons) button.enabled = false;
        }
    }
}
