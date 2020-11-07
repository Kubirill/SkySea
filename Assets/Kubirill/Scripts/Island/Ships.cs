using PathCreation.Examples;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{
    // Start is called before the first frame update

    public int numShip;
    PathFollower pf;
    void Start()
    {
        pf = GetComponent<PathFollower>();
        pf.speed = 0f;
        StartCoroutine( WaitTurn());
        //pf.speed = 5f;
    }

    IEnumerator WaitTurn()
    {
        yield return new WaitForSeconds(3f*numShip);
        pf.speed = 5f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
