using DG.Tweening;
using UnityEngine;
public class Rotate : MonoBehaviour {

	[SerializeField] Transform plot;
	[SerializeField] bool left;
	[SerializeField] float smooth = 0.3f;
	[SerializeField] float angle = 15;

	[SerializeField] AudioClip buttonSound;
	AudioSource _audioSource;
	private void Start () => _audioSource = this.gameObject.GetComponent<AudioSource> ();

	private void OnTriggerEnter () => _audioSource.Play ();

	private void OnTriggerExit () => _audioSource.Play ();

    /*private void OnTriggerStay () =>
		 plot.DORotate (new Vector3 (0, plot.rotation.eulerAngles.y +
			(angle * (left ? -1 : 1)), 0), smooth);*/
    public void OnTriggerStay(Collider other)
    {
		
		if ((other.tag=="Dragon")&&other.gameObject.GetComponent<DragonMove>().anim.GetBool("Finish")) plot.DORotate(new Vector3(0, plot.rotation.eulerAngles.y +	(angle * (left ? -1 : 1)), 0), smooth);
	}
}