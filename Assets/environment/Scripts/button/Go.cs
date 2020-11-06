using DG.Tweening;
using UnityEngine;

public class Go : MonoBehaviour {
    [SerializeField] Transform hero;
    [SerializeField] float speed = 1;
    public void OnTriggerStay () {
        // hero.Translate (this.transform.forward * 1 * Time.deltaTime, Space.World);
        // hero.DOMove (this.transform.forward, speed);
        hero.Translate (hero.forward * 20 * Time.deltaTime);
        // print ($"10. Go -> this.transform.forward : {this.transform.forward}");
    }
}