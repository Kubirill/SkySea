using System.Collections;
using DG.Tweening;
using UnityEngine;
public class WaitRock : MonoBehaviour {
    [SerializeField] Transform sign;
    AudioSource _audioSource;
    private void Start () => _audioSource = this.GetComponent<AudioSource> ();

    private void OnTriggerEnter (Collider other) {
        _audioSource.Play ();
        other.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (-25, -50, -25), ForceMode.Impulse);
        StartCoroutine (rotate ());
    }
    IEnumerator rotate () {
        yield return new WaitForSeconds (0.1f);
        sign.DORotate (new Vector3 (-90, -139, 0), 10f);
    }
}