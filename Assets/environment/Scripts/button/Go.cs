﻿using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Go : MonoBehaviour {
    [SerializeField] Transform hero;
    [SerializeField] float speed = 0;
    [SerializeField] float maxspeed = 20;
    Transform buff;
    bool afterGo = false;

    [SerializeField] AudioClip buttonSound;
    AudioSource _audioSource;
    private void Start () => _audioSource = this.gameObject.GetComponent<AudioSource> ();

    public void OnTriggerStay () => move ();
    // smooth for start
    private void OnTriggerEnter (Collider other) {
        _audioSource.Play ();
        DOTween.To (() => speed, x => speed = x, maxspeed, 1);
    }
    // smooth for end
    private void OnTriggerExit () {
        DOTween.To (() => speed, x => speed = x, 0, 1);
        afterGo = true;
        _audioSource.Play ();
        StartCoroutine (AfterMove ());
    }
    IEnumerator AfterMove () {
        yield return new WaitForSeconds (1f);
        afterGo = false;
    }
    private void FixedUpdate () {
        if (afterGo)
            move ();
        else return;
    }
    // move object
    void move () => hero.Translate (hero.forward * speed * Time.deltaTime, Space.World);
}