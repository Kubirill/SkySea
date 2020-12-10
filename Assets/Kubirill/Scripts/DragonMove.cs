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
        if (isFood&& Vector3.Distance(transform.position, target.transform.position)>25)
        {
            target = targetLazer;
            isFood = false;
        }
        if (target==targetLazer) isFood = false;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dizzy"))
        {
            transform.DOLookAt(player.position, duration/5);
            //rb.useGravity = true;
        }
        if (target.activeInHierarchy)
        {
            if (((Vector3.Distance(target.transform.position-new Vector3(0, target.transform.position.y, 0) , transform.position - new Vector3(0, transform.position.y, 0))  > 0.6f))|| (Vector3.Distance(targetLazer.transform.up, Vector3.up) > 0.1)) anim.SetBool("Finish", false);
            else if ((Vector3.Distance(target.transform.position - new Vector3(0, target.transform.position.y, 0), transform.position - new Vector3(0, transform.position.y, 0)) < 0.3f))
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
            //addTarget = Vector3.zero;
            addTarget = targetLazer.transform.up.normalized/2;
            //if (Vector3.Distance(targetLazer.transform.up, Vector3.up) < 0.1) addTarget = new Vector3(0, 0.5f, 0);


            rb.useGravity = false;
            transform.DOLookAt(target.transform.position, duration / 5);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                if ((transform.position.y >= transform.parent.worldToLocalMatrix.MultiplyPoint(target.transform.position).y) || (Vector3.Distance(transform.position, target.transform.position) < 10))
                {
                    transform.DOLocalMove(transform.parent.worldToLocalMatrix.MultiplyPoint(target.transform.position) + addTarget / 2, duration - (isFood ? 1 : 0));

                }
                else transform.DOLocalMoveY(transform.parent.worldToLocalMatrix.MultiplyPoint(target.transform.position).y + addTarget.y / 2+1, (duration - (isFood ? 1 : 0))/2);
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
