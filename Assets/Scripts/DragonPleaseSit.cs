using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPleaseSit : MonoBehaviour
{
    [SerializeField] Rigidbody dragonRigidbody;
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Dragon")
        {
            if (other.gameObject.GetComponent<DragonMove>().anim.GetBool("Finish"))
            {
                //smooth for start
                dragonRigidbody.isKinematic = true;
            }
        }

    }
}
