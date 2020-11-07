using UnityEngine;

public class Voice : MonoBehaviour {

	[SerializeField] AudioClip[] _voiceClips;
	AudioSource _audioSource = null;
	void Start () {
		_audioSource = this.gameObject.GetComponent<AudioSource> ();
		PlayNextSong ();
	}
	//Play a list of voices in random order
	void PlayNextSong () {
		PlayVoice ();
		Invoke ("PlayNextSong", _audioSource.clip.length + Random.Range (3, 30));
	}
	public void PlayVoice () {
		if (_audioSource != null) {
			_audioSource.clip = _voiceClips[Random.Range (0, _voiceClips.Length)];
			_audioSource.Play ();
		}

	}
}