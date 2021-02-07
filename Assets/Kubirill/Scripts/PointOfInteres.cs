using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInteres : MonoBehaviour
{
    GameObject dragon;
    public float distance;
    DragonMove script;
    // Start is called before the first frame update
    void Start()
    {
        dragon = GameObject.FindGameObjectWithTag("Dragon");
        script = dragon.GetComponent<DragonMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((script.pointOfInteres==script.player|| script.pointOfInteres ==null) && Vector3.Distance(transform.position, dragon.transform.position) < distance)
        {
            script.pointOfInteres = gameObject.transform;
        }
        if ((script.pointOfInteres == transform) && Vector3.Distance(transform.position, dragon.transform.position) > distance+5)
        {
            script.pointOfInteres = script.player;
        }
    }
}
