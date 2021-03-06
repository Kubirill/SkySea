using DG.Tweening;
using UnityEngine;
public class firsttask : MonoBehaviour {

	[SerializeField] AudioClip buttonSound;
	[SerializeField] Transform cloud;
	[SerializeField] Transform goalLeft;
	[SerializeField] Transform goalRight;
	[SerializeField] Transform Button;
	GameObject dragon;

	AudioSource _audioSource;
	private void Start()
	{
		_audioSource = this.gameObject.GetComponent<AudioSource>();
		dragon = GameObject.FindGameObjectWithTag("Dragon");
	}

	private void OnTriggerEnter () => pressB ();

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Q))
			pressB ();
	}
	void pressB () {
		_audioSource.Play ();
		dragon.GetComponent<Animator>().SetTrigger("CatsSave");
		goalLeft.DORotate (new Vector3 (0, 90, 0), 10);
		goalRight.DORotate (new Vector3 (0, -90, 0), 10);
		cloud.transform.DOScale (new Vector3 (0, 0, 0), 5f);
		Button.DOScale (new Vector3 (0, 0, 0), 0.1f);
		//Destroy (Button.gameObject, 12);
		Destroy (cloud.gameObject, 5);
	}
}