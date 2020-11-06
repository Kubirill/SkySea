using DG.Tweening;
using UnityEngine;

public class Go : MonoBehaviour {
    [SerializeField] Transform hero;
    [SerializeField] float speed = 20;
    public void OnTriggerStay () =>
        hero.Translate (hero.forward * speed * Time.deltaTime, Space.World);
}