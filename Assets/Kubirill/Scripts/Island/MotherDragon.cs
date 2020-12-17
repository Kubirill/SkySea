using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDragon : MonoBehaviour
{
    public SkinnedMeshRenderer sleepDragomMesh;
    public SkinnedMeshRenderer openDragomMesh;
    public Mesh happyDragonModel;
    public Animator sleepDragomAnim;
    public Animator openDragomAnim;
    // Start is called before the first frame update
   

    public void OpenEyes()
    {
        openDragomMesh.enabled = true;
        sleepDragomMesh.enabled = false;
        sleepDragomMesh.sharedMesh = happyDragonModel;
        sleepDragomAnim.SetTrigger("Start");
        openDragomAnim.SetTrigger("Start");
    }
    public void ClossEyes()
    {
        openDragomMesh.enabled = false;
        sleepDragomMesh.enabled = true;
    }


}
