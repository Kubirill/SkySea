using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    Vector3 start;
    Rigidbody rb;
    public Animator anim;
    string playing = "deeze";
    public GameObject target;
    public GameObject targetLazer;
    Vector3 addTarget = Vector3.zero;
    public Transform player;
    public Transform pointOfInteres;
    public float duration;
    public float jump;
    public float jumpDuration;
    public float limitY;
    public int num;
    bool isJumping=false;
    public bool isFood=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        start = transform.localPosition;
        if (target == null) target = targetLazer;
    }


    // Update is called once per frame
    void Update()
    {
        if (isFood&& Vector3.Distance(transform.position, target.transform.position)>15)
        {
            target = targetLazer;
            isFood = false;
        }
        if (target==targetLazer) isFood = false;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dizzy"))
        {
            if (pointOfInteres == null) pointOfInteres = player;
            transform.DOLookAt(pointOfInteres.position, duration/5);
            //rb.useGravity = true;
        }
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("idle")|| (anim.GetCurrentAnimatorStateInfo(0).IsName("stirr_on_ground")) && pointOfInteres !=player))
        {
            
            transform.DOLookAt(pointOfInteres.position, duration / 5);
            //rb.useGravity = true;
        }
        if (target.activeInHierarchy)
        {
            if (((Vector3.Distance(target.transform.position-new Vector3(0, target.transform.position.y, 0) , transform.position - new Vector3(0, transform.position.y, 0))  > 0.5f))||(addTarget==Vector3.zero)) anim.SetBool("Finish", false);
            else
            {

                if (!anim.GetBool("Finish"))
                {
                    //transform.DOLookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 0.1f);
                    rb.useGravity = true;
                    rb.velocity = Vector3.zero;
                    //transform.transform.localPosition= new Vector3(target.transform.localPosition.x, transform.localPosition.y, target.transform.localPosition.z);
                    transform.transform.DOPause();
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
            addTarget = Vector3.zero;
            if (Vector3.Distance(targetLazer.transform.up, Vector3.up) < 0.1) addTarget = new Vector3(0, 0.5f, 0);


            rb.useGravity = false;
            transform.DOLookAt(target.transform.position + addTarget, duration / 5);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                transform.DOLocalMove( transform.parent.worldToLocalMatrix.MultiplyPoint(target.transform.position)  + addTarget, duration - (isFood ? 1 : 0));
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            target = other.gameObject;
            anim.SetTrigger("Food");
        }
    }

    public void Eat()
    {
        if (isFood)
        {
            GameObject.Destroy(target);
            target = targetLazer;
            isFood = false;
        }

    }
    public void LateUpdate()
    {
        if (isFood) transform.DOLookAt(target.transform.position , duration / 5);
        if (transform.position.y < limitY) transform.position = start;
    }
}
