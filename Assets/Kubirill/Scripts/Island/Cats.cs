using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    public GameObject player;
    public GameObject dragon;
    public Transform targetJump;
    public Transform safeJump;

    public Transform BackWall;
    public Transform LeftWall;
    public Transform RightWall;

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
                    transform.DOLocalMoveX(Mathf.Max( transform.localPosition.x - transform.forward.x / 5, BackWall.localPosition.x) ,0.5f);
                    transform.DOLocalMoveZ(Mathf.Clamp( transform.localPosition.z - transform.forward.z / 5, RightWall.localPosition.z,LeftWall.localPosition.z) ,0.5f);
                }

            }
            else
            {
                anim.SetTrigger("Idle");
                transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            }
        }
        else
        {
            anim.SetTrigger("Idle");
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }
    }
  
    public void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.tag + " " + name);
        if (other.tag== "SafeZone")
        {
            isAfraid = false;
            transform.parent = dragon.transform.parent;
            anim.SetTrigger("Idle");
            rb.isKinematic = true;
            rb.useGravity = false;
            transform.DOMove(safeJump.position, 1);
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            //GetComponent<Collider>().isTrigger = true;
        }
        if (other.tag == "StopForCats")
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            transform.parent = null;
            transform.DOJump(targetJump.position, 1, 1, 1);
            transform.LookAt(targetJump.position);
            anim.SetTrigger("Idle");
            isStop = true;
        
        }
        if ((other.tag == "PlotForCats")&&isAfraid)
        {
            //Debug.Log(other.tag + "plooot " + name);
            transform.DOPause();
            isAfraid = false;
            transform.parent = dragon.transform.parent;
            rb.isKinematic = false;
            rb.useGravity = true;
            transform.parent = null;
            transform.DOJump(safeJump.position, 1, 1, 1);
            transform.LookAt(safeJump.position);
            anim.SetTrigger("Walk");
            

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlotForCats")
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            transform.parent = null;
            transform.DOJump(safeJump.position, 3, 1, 3);
            transform.LookAt(safeJump.position);
            anim.SetTrigger("Walk");
            isStop = true;

        }
    }
}
