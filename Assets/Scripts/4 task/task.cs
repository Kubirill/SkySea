using System.Collections;
using DG.Tweening;
using PathCreation.Examples;
using UnityEngine;
public class task : MonoBehaviour {
    [SerializeField] Transform RightDoor;
    [SerializeField] Transform leftDoor;
    [SerializeField] AudioClip shootSound;
    [SerializeField] Transform Catapult;
    [SerializeField] Transform Barrel;
    [SerializeField] Transform shootBarrel;
    [SerializeField] GameObject ParentShootBarrel;
    bool shootBarrelOnRightPlace = false;
    AudioSource _audioSource;
    [SerializeField] GameObject rope0;
    [SerializeField] GameObject rope1;
    [SerializeField] GameObject rope2;
    bool[] cut = { false, false, false, false };

    private void Start () {
        _audioSource = this.gameObject.GetComponent<AudioSource> ();
    }

    public void Cut (int id) {
        switch (id) {
            case 0:
                print ("cut 0");
                if (cut[1] == true && shootBarrelOnRightPlace) {
                    fallBarrel ();
                    Destroy (rope0);
                    Destroy (rope2);
                }
                break;
            case 1:
                print ("cut 1");
                if (shootBarrelOnRightPlace) {
                    fallBarrel ();
                    Destroy (rope1);
                }
                break;
            case 2:
                print ("cut 2");
                if (cut[3] == true)
                    fallCatapults ();
                break;
            case 3:
                if (cut[2] == true)
                    fallCatapults ();
                print ("cut 3");
                break;
        }
        cut[id] = true;

    }

    void fallCatapults () {
        Catapult.DOMove (new Vector3 (Catapult.position.x, Catapult.position.y - 152.5f, Catapult.position.z), 2f);
        Catapult.DORotate (new Vector3 (-18, 0, 0), 2f);
        print ($"53. task ->  Catapult.position.y - 90 : { Catapult.position.y - 145}");
        ShootBarrelUnfreeze ();
    }
    void fallBarrel () {
        Barrel.DOMove (new Vector3 (Barrel.position.x, Barrel.position.y - 205.5f, Barrel.position.z), 2f);
        StartCoroutine (shoot (2f));
    }
    void ShootBarrelUnfreeze () =>
        shootBarrel.GetComponent<Rigidbody> ().isKinematic = false;

    public void OnRightPlaceShootBarrel () {
        shootBarrelOnRightPlace = true;
        shootBarrel.GetComponent<Rigidbody> ().isKinematic = true;
        print ($"69. task -> shootBarrelOnRightPlace : {shootBarrelOnRightPlace}");
    }

    IEnumerator shoot (float time) {
        yield return new WaitForSeconds (time);
        shootBarrel.GetComponent<Rigidbody> ().isKinematic = false;
        ParentShootBarrel.GetComponent<PathFollower> ().enabled = true;
        StartCoroutine (openDoor ());
        // _audioSource.Play ();
    }
    IEnumerator openDoor () {
        yield return new WaitForSeconds (0.3f);
        leftDoor.DORotate (new Vector3 (0, 90, 0), 10);
        RightDoor.DORotate (new Vector3 (0, -90, 0), 10);
    }
}