using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortiles : MonoBehaviour
{
    GameObject dragon;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        dragon = GameObject.FindGameObjectWithTag("Dragon");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance(transform.position, dragon.transform.position) < 10)
        {
            anim.SetBool("Dangerous", true);

        }
        else anim.SetBool("Dangerous", false);
    }
}
