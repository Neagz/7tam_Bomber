using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed = 5F;
    [SerializeField] private float speeding = 0.1F;
    public Animator animator;
    public GameObject topBorder;
    public GameObject bottomBorder;
    public Rigidbody2D rigidBody;
    public bool isTopDirection;

    private void Update()
    {

        if (isTopDirection)
        {
            animator.SetTrigger("StartUp");
            rigidBody.velocity = Vector2.up * speed + Vector2.right * speeding;
            if (transform.position.y > topBorder.transform.position.y)
            {
                animator.SetTrigger("StopUp");
                isTopDirection = !isTopDirection; 
            } 
        }

        else
        {
            animator.SetTrigger("StartDown");
            rigidBody.velocity = Vector2.down * speed + Vector2.left * speeding;
            if (transform.position.y < bottomBorder.transform.position.y)
            {
                animator.SetTrigger("StopDown");
                isTopDirection = !isTopDirection;
            }
        }
    }
}
