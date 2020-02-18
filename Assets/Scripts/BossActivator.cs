using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject theBossBatle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theBossBatle.SetActive(true);
            gameObject.SetActive(false);

            AudioManager.instance.PlayBossMusic();
        }
    }
}
