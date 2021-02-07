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
    public MeshRenderer meshRend;
    bool active = false;
    Animator anim;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {

        if ((collision.gameObject.tag == "Dragon")&&(!active))
        {

            anim.SetBool("Press", true);
        }
    }

    public void SetMain(Level1 scriptObj)
    {
        mainScript = scriptObj;
        anim = GetComponent<Animator>();
    }
    public void SetMaterial(string type)
    {
        
        switch (type)
        {
            case "wrong":
                anim.SetBool("Press", false);
                meshRend.materials = changeMaterial(wrong,1);
                active = false;
                break;
            case "correct":
                
                Debug.Log("correct");
                meshRend.materials = changeMaterial(correct, 1) ;
                
                active = true;
                break;
            default:
                anim.SetBool("Press", false);
                meshRend.materials = changeMaterial(unactive, 1);
                active = false;
                break;
        }

    }
    public Material[] changeMaterial(Material mat, int numInArray)
    {
        Material[] newMat = meshRend.materials;
        newMat[numInArray] = mat;
        return newMat;
    }

    public void Press()
    {
        mainScript.Press(number);
    }

    public void Releese()
    {
        mainScript.Releese();
    }
}
