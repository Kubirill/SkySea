using DG.Tweening;
using UnityEngine;
public class ButtonTask : MonoBehaviour {

    [SerializeField] Transform RightDoor;
    [SerializeField] Transform leftDoor;

    [SerializeField] AudioClip buttonSound;
    AudioSource _audioSource;
    bool alreadyPress = false;
    private void Start () => _audioSource = this.gameObject.GetComponent<AudioSource> ();

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "barrel" && !alreadyPress) openDoors ();
    }

    void openDoors () {
        leftDoor.DORotate (new Vector3 (0, 90, 0), 10);
        RightDoor.DORotate (new Vector3 (0, -90, 0), 10);
        _audioSource.Play ();
        alreadyPress = true;
    }

}