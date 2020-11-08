using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {
    public GameObject lazerPoint;
    [SerializeField] bool useNormalLaser = false;
    public float MaxDistance;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;
        RaycastHit point;
        if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward * 2 - (useNormalLaser ? Vector3.zero : Vector3.up)), out point, MaxDistance, layerMask) && (point.collider.gameObject.layer == 8)) {
            if (Vector3.Distance (transform.position, point.transform.position) > 15) lazerPoint.GetComponent<MeshRenderer> ().enabled = true;
            else lazerPoint.GetComponent<MeshRenderer> ().enabled = false;
            lazerPoint.SetActive (true);
            Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * point.distance, Color.red);
            lazerPoint.transform.position = new Vector3 (point.point.x, point.point.y, point.point.z);
            lazerPoint.transform.up = point.normal;
        } else {
            lazerPoint.SetActive (false);
        }
    }
}