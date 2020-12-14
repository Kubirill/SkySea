using System.Collections;
using DG.Tweening;
using UnityEngine;
public class Rotate : MonoBehaviour
{

    [SerializeField] Transform plot;
    [SerializeField] Rigidbody plotRb;
    [SerializeField] Rigidbody DragonRigidbody;

    [SerializeField] bool left;
    [SerializeField] float smooth = 0.3f;
    [SerializeField] float angle = 15;

    [SerializeField] AudioClip buttonSound;
    Animator anim;
    AudioSource _audioSource;
    private void Start()
    {
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dragon" && (anim.GetBool("Press")))
        {
            _audioSource.Play();
            anim.SetBool("Press", false);
        }
        DragonRigidbody.isKinematic = false;
    }

    /*private void OnTriggerStay () =>
		 plot.DORotate (new Vector3 (0, plot.rotation.eulerAngles.y +
			(angle * (left ? -1 : 1)), 0), smooth);*/
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Dragon")
        {

            if (other.gameObject.GetComponent<DragonMove>().anim.GetBool("Finish"))
            {
                if (!anim.GetBool("Press"))
                {
                    DragonRigidbody.isKinematic = true;
                    anim.SetBool("Press", true);
                    _audioSource.Play();
                }
                Rotation();
            }
            else
            {
                if (anim.GetBool("Press"))
                {
                    anim.SetBool("Press", false);
                    _audioSource.Play();
                }
            }
        }
    }
    IEnumerator MakeDragonKinematic()
    {
        yield return new WaitForSeconds(1f);
        DragonRigidbody.isKinematic = anim.GetBool("Press");

    }
    void Rotation()
    {
        plotRb.DORotate(new Vector3(0, plot.rotation.eulerAngles.y + (angle * (left ? -1 : 1)), 0), smooth);
    }
}