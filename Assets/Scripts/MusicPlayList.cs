using DG.Tweening;
using UnityEngine;
//Play a list of tracks in random order
public class MusicPlayList : MonoBehaviour
{
    [SerializeField] AudioClip[] _musicClips;
    AudioSource _audioSource = null;
    int songNum;
    void Start()
    {
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        PlayNextSong(0);
        _audioSource.volume = 0;
    }
    //Play a list of tracks in random order
    void PlayNextSong()
    {
        _audioSource.clip = _musicClips[Random.Range(0, _musicClips.Length)];
        _audioSource.Play();
        //Invoke ("PlayNextSong", _audioSource.clip.length);
    }
    public void PlayNextSong(int num)
    {
        DOTween.To(() => _audioSource.volume, x => _audioSource.volume = x, 0, 3);
        songNum = num;
        Invoke("PlayNextSongNow", 3);
        //Invoke ("PlayNextSong", _audioSource.clip.length);
    }
    void PlayNextSongNow()
    {
        _audioSource.clip = _musicClips[songNum];
        _audioSource.Play();
        DOTween.To(() => _audioSource.volume, x => _audioSource.volume = x, 1, 1);
        Invoke("PlayNextSong", _audioSource.clip.length);
    }
}
