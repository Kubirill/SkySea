using DG.Tweening;
using UnityEngine;
public class ButtonTask : MonoBehaviour {

    [SerializeField] Transform RightDoor;
    [SerializeField] Transform leftDoor;

    [SerializeField] AudioClip buttonSound;
    AudioSource _audioSource;
    bool alreadyPress = false;
    GameObject dragon;

    private void Start()
    {
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        dragon = GameObject.FindGameObjectWithTag("Dragon");
    }

        private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "barrel" && !alreadyPress) openDoors ();
    }

    void openDoors () {
        dragon.GetComponent<Animator>().SetTrigger("CatsSave");
        leftDoor.DORotate (new Vector3 (0, 90, 0), 10);
        RightDoor.DORotate (new Vector3 (0, -90, 0), 10);
        _audioSource.Play ();
        alreadyPress = true;
    }

}