using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonLevel1 : MonoBehaviour
{
    Level1 mainScript;
    public int number;
    public Material wrong;
    public Material correct;
    public Material unactive;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Dragon")&&(gameObject.GetComponent<MeshRenderer>().material!= correct))
        {
            

            mainScript.Press(number);
        }
    }

    public void SetMain(Level1 scriptObj)
    {
        mainScript = scriptObj;
    }
    public void SetMaterial(string type)
    {
        switch (type)
        {
            case "wrong": 
                gameObject.GetComponent<MeshRenderer>().material= wrong;
                break;
            case "correct": 
                gameObject.GetComponent<MeshRenderer>().material = correct;
                break;
            default:
                gameObject.GetComponent<MeshRenderer>().material = unactive;
                break;
        }

    }
}
