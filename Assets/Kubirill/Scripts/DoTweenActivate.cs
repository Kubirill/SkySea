using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenActivate : MonoBehaviour
{
    public Transform targetEnd;
    public Transform targetStart;
    public float speed;
    public bool isDestoyed;

    
    // Update is called once per frame
    void Update()
    {
        if (isDestoyed)
        {
            if (transform.localScale.x <= (targetEnd.localScale.x * 1.1f))
            {
                transform.DOComplete();
                Destroy(gameObject);
            }
        }
    }
    public void GoToEnd()
    {
        transform.DOMove(targetEnd.position, speed);
        transform.DORotateQuaternion(targetEnd.rotation, speed);
        transform.DOScale(targetEnd.localScale, speed);
    }
    public void GoToStart()
    {
        transform.DOMove(targetStart.position, speed);
        transform.DORotateQuaternion(targetStart.rotation, speed);
        transform.DOScale(targetStart.localScale, speed);
    }
}
