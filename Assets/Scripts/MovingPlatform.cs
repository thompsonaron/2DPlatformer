using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public Transform platform;


    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(platform.position, points[currentPoint].position) < 0.5f)
        {
            
            currentPoint++;
            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }


    //// Keeps plater attach to moving platform -> Bugged TODO
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("WHOT");
    //        other.transform.parent = this.transform;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.transform.parent = null;
    //    }
    //}
}
