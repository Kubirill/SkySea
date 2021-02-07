using UnityEngine;
using DG.Tweening;
using System.Collections;

public class LookAtButton : MonoBehaviour
{
    [SerializeField] GameManager menu;
    [SerializeField] bool isItStart;
    [SerializeField] CapsuleCollider appleCollider;
    bool bigLaser = false;
    GameObject laser;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Laser") && !bigLaser)
        {
            other.gameObject.transform.DOScale(other.gameObject.transform.localScale * 2, 0.5f);
            bigLaser = true;
            StartCoroutine(Press(other.gameObject));
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Laser") && bigLaser)
        {
            var laserScale = other.gameObject.transform.localScale;
            other.gameObject.transform.DOScale(other.gameObject.transform.localScale / 2, 0.5f);
            bigLaser = false;
        }
    }

    IEnumerator Press(GameObject laser)
    {
        yield return new WaitForSeconds(1f);
        // if we still focused on button, we press
        if (bigLaser == true)
            if (isItStart)
            {
                laser.transform.DOScale(laser.transform.localScale / 2, 0.5f);
                appleCollider.enabled = true;
                appleCollider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                laser.GetComponent<SphereCollider>().enabled = false;
                menu.PressStart();
            }
            else
                menu.Restart();
    }
}
