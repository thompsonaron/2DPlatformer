﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;

    public SpriteRenderer theSR;

    public float moveTime, waitTime;
    private float moveCount, waitCount;
    private Animator anim;

    [Header("Taking damage")]
    public int health;
   // public float speed;
    private float dazedTimer;
    public float startDazedTime;
    public GameObject bloodEffect;

    void Start()
    {
        theRB = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTimer <= 0)
        {
            moveSpeed = 5;
            anim.SetBool("isMoving", true);
        }
        else
        {
            moveSpeed = 0;
            dazedTimer -= Time.deltaTime;
            
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }


        if (moveCount > 0 && dazedTimer <= 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                theSR.flipX = true;
                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                theSR.flipX = false;
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        }
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, moveTime * 1.25f); ;
                
            }
            anim.SetBool("isMoving", false);
        }
        
    }

    public void TakeDamage(int damage)
    {
        dazedTimer = startDazedTime;
        anim.SetBool("isMoving", false);
        theRB.velocity = new Vector2(0, theRB.velocity.y);

        if (bloodEffect != null)
        {
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }

        health -= damage;
    }
}
