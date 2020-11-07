using DG.Tweening;
using UnityEngine;
public class SecondTask : MonoBehaviour {
	[SerializeField] AudioClip buttonSound;
	[SerializeField] Transform cloud;
	[SerializeField] Transform goalLeft;
	[SerializeField] Transform goalRight;
	[SerializeField] Transform Button;

	AudioSource _audioSource;
	private void Start () => _audioSource = this.gameObject.GetComponent<AudioSource> ();

	private void OnTriggerEnter () => pressB ();

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Q))
			pressB ();
	}
	void pressB () {
		_audioSource.Play ();
		goalLeft.DORotate (new Vector3 (0, 90, 0), 10);
		goalRight.DORotate (new Vector3 (0, -90, 0), 10);
		cloud.transform.DOScale (new Vector3 (0, 0, 0), 5f);
		Button.DOScale (new Vector3 (0, 0, 0), 0.1f);
		Destroy (Button.gameObject, 7);
		Destroy (cloud.gameObject, 5);
	}
}