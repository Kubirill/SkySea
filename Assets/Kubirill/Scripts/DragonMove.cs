using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    string playing = "deeze";
    public GameObject target;
    public Transform player;
    public float duration;
    public float jump;
    public float jumpDuration;
    public int num;
    bool isJumping=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("dizzy"))
        {
            transform.DOLookAt(player.position, duration/5);
            rb.useGravity = true;
        }
        if (target.activeInHierarchy)
        {
            if ((Vector3.Distance(target.transform.position - new Vector3(0, target.transform.position.y, 0), transform.position - new Vector3(0, transform.position.y, 0)) > 0.4f)) anim.SetBool("Finish", false);
            else
            {

                if (!anim.GetBool("Finish"))
                {
                    transform.DOLookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 0.1f);

                    transform.DOMove ( new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z),1);
                }
                anim.SetBool("Finish", true);
                rb.DOPause();
                
            }

            anim.SetBool("FindTarget", true);
            
            
            
        }
        else
        {
            anim.SetBool("FindTarget", false);
            rb.velocity = Vector3.zero;
        }
        if (!anim.GetBool("Finish"))
        {
            Vector3 addTarget = Vector3.zero;
            if (Vector3.Distance(target.transform.up, Vector3.up) < 0.2) addTarget = new Vector3(0, 1.8f, 0);


            rb.useGravity = false;
            transform.DOLookAt(target.transform.position + addTarget, duration / 5);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                 rb.DOMove(target.transform.position + addTarget, duration);
               
            }
        }


        

    }
}
