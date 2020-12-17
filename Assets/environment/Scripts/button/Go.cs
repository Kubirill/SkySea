using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Go : MonoBehaviour
{
    // move boat
    [SerializeField] GameObject hero;
    Transform heroTransform;
    Rigidbody heroRigidbody;
    [SerializeField] GameObject dragon;
    Rigidbody dragonRigidbody;
    Transform dragonTransform;
    [SerializeField] float speed = 0;
    [SerializeField] float maxspeed = 20;
    // Transform buff;
    bool afterGo = false;

    [SerializeField] AudioClip buttonSound;
    Animator anim;
    AudioSource _audioSource;

    private void Start()
    {
        heroTransform = hero.GetComponent<Transform>();
        heroRigidbody = hero.GetComponent<Rigidbody>();
        dragonRigidbody = dragon.GetComponent<Rigidbody>();
        dragonTransform = dragon.GetComponent<Transform>();
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Dragon")
        {
            if (other.gameObject.GetComponent<DragonMove>().anim.GetBool("Finish"))
            {
                if (!anim.GetBool("Press"))
                {
                    //smooth for start
                    DOTween.To(() => speed, x => speed = x, maxspeed, 1); // to max speed, duration 1
                    anim.SetBool("Press", true);
                    dragonRigidbody.isKinematic = true;
                    _audioSource.Play();
                }
                move();
            }
            else
            {
                SmoothEnd();
            }
        }

    }

    // smooth for end
    void SmoothEnd()
    {
        if (anim.GetBool("Press"))
        {
            // we stop go
            DOTween.To(() => speed, x => speed = x, 0, 1); // to 0, duration 1
            afterGo = true;
            _audioSource.Play();
            StartCoroutine(AfterMove());
            anim.SetBool("Press", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dragon")
        {
            
            SmoothEnd();
        }

    }
    IEnumerator AfterMove()
    {
        yield return new WaitForSeconds(1f);
        afterGo = false;
        dragonRigidbody.isKinematic = anim.GetBool("Press"); ;
    }
    private void FixedUpdate()
    {
        heroRigidbody.isKinematic = !dragonRigidbody.isKinematic;
        if (speed == 0)
        {
            
            heroRigidbody.isKinematic = true;
            heroRigidbody.isKinematic = false;
        }
        if (afterGo)
            move();
        else return;
    }
    // move object with rigidbody
    void move()
    {
        // Vector3 powerOfMove = new Vector3 ()
        var powerOfMove = heroTransform.forward * speed; // set direction of movement (forward)
        // without physics
        // heroTransform.Translate (powerOfMove * Time.deltaTime, Space.World);
        heroRigidbody.velocity = powerOfMove;
    }
}

