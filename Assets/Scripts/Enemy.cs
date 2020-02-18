using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTimer;
    public float startDazedTime;

    private Animator anim;
    public GameObject bloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (dazedTimer <= 0)
        //{
        //    speed = 5;
        //}
        //else
        //{
        //    speed = 0;
        //    dazedTimer -= Time.deltaTime;
        //}

        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //}

        //transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        //dazedTimer = startDazedTime;

        //if (bloodEffect != null)
        //{
        //    Instantiate(bloodEffect, transform.position, Quaternion.identity);
        //}
        
        health -= damage;
        Debug.Log("damage TAKEN!");
    }
}
