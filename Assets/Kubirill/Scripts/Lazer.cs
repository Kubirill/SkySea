using System.Collections;
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
        RaycastHit point;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out point,MaxDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * point.distance, Color.red);
            lazerPoint.transform.position = new Vector3(point.point.x, point.point.y, point.point.z);
            lazerPoint.transform.up = point.normal;
        }
    }
}
