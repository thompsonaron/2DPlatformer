using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour
{
    public GameObject slammer;
    public GameObject slammerTarget;
    public float slamSpeed;
    public float waitAfterSlam;
    public float resetSpeed;
    private bool slammerReady;
    private bool triggered;


    // Start is called before the first frame update
    void Start()
    {
        slammerReady = true;
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            slammer.transform.position =  Vector3.MoveTowards(slammer.transform.position, slammerTarget.transform.position, slamSpeed * Time.deltaTime);
            
        }else if(Vector3.Distance(slammer.transform.position, this.transform.position) > 0.1f && !triggered)
        {
            slammer.transform.position = Vector3.MoveTowards(slammer.transform.position, this.transform.position, resetSpeed * Time.deltaTime);
            if (Vector3.Distance(slammer.transform.position, this.transform.position) <= 0.1f)
            {
                slammerReady = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player" && slammerReady)
        {
            triggered = true;
            slammerReady = false;
            StartCoroutine(MoveBack());
        }
    }

    private IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(waitAfterSlam);
        triggered = false;       
    }
}
