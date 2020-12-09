using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Go : MonoBehaviour {
    [SerializeField] Transform hero;
    [SerializeField] float speed = 0;
    [SerializeField] float maxspeed = 20;
    Transform buff;
    bool afterGo = false;

    [SerializeField] AudioClip buttonSound;
    Animator anim;
    AudioSource _audioSource;
    private void Start()
    {
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
    }

    /*public void OnTriggerStay () => move ();*/
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Dragon")
        {
            if (other.gameObject.GetComponent<DragonMove>().anim.GetBool("Finish"))
            {
                if (!anim.GetBool("Press"))
                {
                   //smooth for start
                    DOTween.To(() => speed, x => speed = x, maxspeed, 1);
                    anim.SetBool("Press", true);
                    _audioSource.Play();
                }
                move();
            }
            else
            {
                if (anim.GetBool("Press"))
                {
                    DOTween.To(() => speed, x => speed = x, 0, 1);
                    afterGo = true;
                    _audioSource.Play();
                    StartCoroutine(AfterMove());
                    anim.SetBool("Press", false);
                }
            }
        }
        
    }
    
    // smooth for end
    private void OnTriggerExit (Collider other) {
        if ((other.tag == "Dragon") &&( anim.GetBool("Press")))
        {
            DOTween.To(() => speed, x => speed = x, 0, 1);
            afterGo = true;
            _audioSource.Play();
            StartCoroutine(AfterMove());
            anim.SetBool("Press", false);
        }
            
    }
    IEnumerator AfterMove () {
        yield return new WaitForSeconds (1f);
        afterGo = false;
    }
    private void FixedUpdate () {
        if (afterGo)
            move ();
        else return;
    }
    // move object
    void move () => hero.Translate (hero.forward * speed * Time.deltaTime, Space.World);
}