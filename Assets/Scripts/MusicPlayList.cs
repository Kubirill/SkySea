using UnityEngine;
//Play a list of tracks in random order
public class MusicPlayList : MonoBehaviour {
    [SerializeField] AudioClip[] _musicClips;
    AudioSource _audioSource = null;
    void Start () {
        _audioSource = this.gameObject.GetComponent<AudioSource> ();
        PlayNextSong ();
    }
    //Play a list of tracks in random order
    void PlayNextSong () {
        _audioSource.clip = _musicClips[Random.Range (0, _musicClips.Length)];
        _audioSource.Play ();
        Invoke ("PlayNextSong", _audioSource.clip.length);
    }
}