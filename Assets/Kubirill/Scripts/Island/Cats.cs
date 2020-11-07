using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    public GameObject player;
    public GameObject dragon;

    GameObject afraid;
    Rigidbody rb;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        afraid = player;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(afraid.transform.position.x, transform.position.y, afraid.transform.position.z));
        if (Vector3.Distance(transform.position, dragon.transform.position) < 5) afraid=dragon;
        if (Vector3.Distance(transform.position, dragon.transform.position) < 3)
        {
            anim.SetTrigger("Walk");
            transform.position = transform.position - transform.forward / 5;
            
        }
    }
}
