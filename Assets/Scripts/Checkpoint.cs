using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSr;

    public Sprite cpOn, cpOff;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointController.instance.DeactivateCheckpoints();
            theSr.sprite = cpOn;
            CheckPointController.instance.SetSpawnPoint(this.transform.position);
        }
    }

    public void ResetCheckPoint()
    {
        theSr.sprite = cpOff;
    }
}
