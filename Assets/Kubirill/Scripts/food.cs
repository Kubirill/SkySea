using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    GameObject dragon;
    DragonMove script;
    // Start is called before the first frame update
    void Start()
    {
        dragon = GameObject.FindGameObjectWithTag("Dragon");
        script = dragon.GetComponent<DragonMove>();
        if ((!script.isFood)&&Vector3.Distance(transform.position,dragon.transform.position)<10)
        {

            script.target = gameObject;
            script.isFood = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!script.isFood && Vector3.Distance(transform.position, dragon.transform.position) < 10)
        {
            script.target = gameObject;
            script.isFood = true;
           
        }
    }
}
