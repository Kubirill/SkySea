using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public Transform targetZone;
    public Transform ship;
    public Collider[] buttons;
    public float speed = 10;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlotForCats")
        {
            ship.DOMove(targetZone.position, speed);
            ship.DORotateQuaternion(targetZone.rotation, speed);

            foreach (Collider button in buttons) button.enabled = false;
            ship.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
