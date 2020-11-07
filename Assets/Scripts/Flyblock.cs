using DG.Tweening;
using PathCreation.Examples;
using UnityEngine;
public class Flyblock : MonoBehaviour {

    float oldHeight;
    [SerializeField] PathFollower path;
    bool fly = false;
    private void Start () {
        path = this.gameObject.GetComponent<PathFollower> ();
    }
    public void go () {
        path.enabled = true;
    }

    private void FixedUpdate () {
        if (Input.GetKeyDown (KeyCode.Q))
            go ();

    }

}