using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10F;
    [SerializeField] private float speeding = 0.145F;
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform bombSpawnPoint;
    private Vector3 direction;
    public Animator animator;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        MotionPlayer();
        CheckBomb();
    }

    private void MotionPlayer()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.up + (Vector3.right * speeding);
            animator.SetTrigger("GoingUp");
        }
        else
        {
            animator.SetTrigger("StoppingUp");
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector3.down + (Vector3.left * speeding);
            animator.SetTrigger("GoingDown");
        }
        else
        {
            animator.SetTrigger("StoppingDown");
        }

        direction *= speed;
        rigidBody.velocity = direction;
        
        /*
        if (direction.x > 0)
            spriteRenderer.flipX = false;
        if (direction.x < 0)
           spriteRenderer.flipX = true;
        */
    }

    void CheckBomb()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bomb, bombSpawnPoint.position, Quaternion.identity);
        }
    }

}
