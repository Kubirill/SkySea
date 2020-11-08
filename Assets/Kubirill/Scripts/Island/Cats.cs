﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    public GameObject player;
    public GameObject dragon;
    public Transform targetJump;

    GameObject afraid;
    Rigidbody rb;
    Animator anim;
    bool isAfraid = true;
    bool isStop = false;
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
        if (!isStop)
        {
            if (isAfraid)
            {
                transform.LookAt(new Vector3(afraid.transform.position.x, transform.position.y, afraid.transform.position.z));
                if (Vector3.Distance(transform.position, dragon.transform.position) < 5) afraid = dragon;
                if (Vector3.Distance(transform.position, dragon.transform.position) < 3)
                {
                    anim.SetTrigger("Walk");
                    transform.position = new Vector3 (Mathf.Lerp(transform.position.x, transform.position.x - transform.forward.x / 5,0.1f), Mathf.Lerp(transform.position.y, transform.position.y - transform.forward.y / 5, 0.1f),Mathf.Lerp(transform.position.z, transform.position.z - transform.forward.z / 5, 0.1f));

                }

            }
            else
            {
                anim.SetTrigger("Idle");
                transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            }
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("col" + collision.gameObject.tag);

        if (collision.gameObject.tag == "SaveZone")
        {
            Debug.Log("col pl");
            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag== "SafeZone")
        {
            isAfraid = false;
            transform.parent = dragon.transform.parent;
            anim.SetTrigger("Idle");
            rb.isKinematic = true;
            rb.useGravity = false;
            GetComponent<Collider>().isTrigger = true;
        }
        if (other.tag == "StopForCats")
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            transform.parent = null;
            transform.DOJump(targetJump.position, 5, 1, 3);
            transform.LookAt(targetJump.position);
            anim.SetTrigger("Idle");
            isStop = true;

        }
    }
}
