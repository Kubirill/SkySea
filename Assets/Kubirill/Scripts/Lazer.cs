﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject lazerPoint;
    public float MaxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;
        RaycastHit point;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out point,MaxDistance,layerMask)&& (point.collider.gameObject.layer ==8))
        {
            
            lazerPoint.SetActive(true);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * point.distance, Color.red);
            lazerPoint.transform.position = new Vector3(point.point.x, point.point.y, point.point.z);
            lazerPoint.transform.up = point.normal;
        }
        else
        {
            lazerPoint.SetActive(false);
        }
    }
}
