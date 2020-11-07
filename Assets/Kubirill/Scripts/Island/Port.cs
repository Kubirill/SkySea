using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Port : MonoBehaviour
{
    public GameObject ship;
    public Animator Dragon;
    public Collider[] buttons;
    public GameObject catsObject;
    public void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player")&&(catsObject.transform.childCount != 0))
        {
            ship.transform.DOMove(transform.parent.position, 4);
            ship.transform.DORotateQuaternion(transform.parent.rotation, 4);
            foreach (Collider button in buttons) button.enabled = false;
        }
    }
    public void Update()
    {
        if (catsObject.transform.childCount == 0)
        {
            foreach (Collider button in buttons) button.enabled = true;
            Dragon.SetTrigger("CatsSave");
            GameObject.Destroy(gameObject);
        }
    }
}
