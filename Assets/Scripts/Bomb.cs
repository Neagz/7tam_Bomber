using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool isGrounded;
    public string tagInstantKill;
    public string tagSecondTouch;
    public string tagExplosionTime;


    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(tagInstantKill))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col2)
    {
        if (col2.gameObject.CompareTag(tagSecondTouch))
        {
            if (isGrounded)
            {
                isGrounded = false;
                Destroy(gameObject);
                Destroy(col2.gameObject);
            }
            else
            {
                StartCoroutine(TimeOut());
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D col3)
    {
        if (col3.gameObject.CompareTag(tagExplosionTime))
        {
            isGrounded = false;
            Destroy(gameObject, 5);
        }
        
    }

    IEnumerator TimeOut()
    {
        isGrounded = true;
        yield return new WaitForSeconds(5);
        isGrounded = false;
    }
    
}
