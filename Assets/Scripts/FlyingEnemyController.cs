using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public SpriteRenderer theSr;

    public float distanceToAttackPlayer, chaseSpeed;

    private Vector3 attackTarget;

    public float waitAfterAttack;
    private float attackCounter;

    [Header("Taking damage")]
    public int health;
    // public float speed;
    private float dazedTimer;
    public float startDazedTime;
    public GameObject bloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in points)
        {
            t.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTimer <= 0)
        {
            moveSpeed = 5;
            
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


        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {

            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttackPlayer)
            {

                attackTarget = Vector3.zero;

                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.5f)
                {

                    currentPoint++;
                    if (currentPoint >= points.Length)
                    {
                        currentPoint = 0;
                    }
                }

                if (transform.position.x < points[currentPoint].position.x)
                {
                    theSr.flipX = true;
                }
                else if (transform.position.x > points[currentPoint].position.x)
                {
                    theSr.flipX = false;
                }
            }
            else
            {
                // attack the player

                if (attackTarget == Vector3.zero)
                {
                    attackTarget = PlayerController.instance.transform.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= 0.1f)
                {

                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        dazedTimer = startDazedTime;
       
       // theRB.velocity = new Vector2(0, theRB.velocity.y);

        if (bloodEffect != null)
        {
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }

        health -= damage;
    }
}
