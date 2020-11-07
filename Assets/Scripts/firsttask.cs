using UnityEngine;

public class firsttask : MonoBehaviour {
	[SerializeField] GameObject cloud;

	[SerializeField] AudioClip buttonSound;
	AudioSource _audioSource;
	private void Start () => _audioSource = this.gameObject.GetComponent<AudioSource> ();

	private void OnTriggerEnter () {
		_audioSource.Play ();
		
	}
}