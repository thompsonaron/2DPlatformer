using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitbox : MonoBehaviour
{
    public BossTankController bossController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && PlayerController.instance.transform.position.y > transform.position.y)
        {
            bossController.TakeHit();

            PlayerController.instance.Bounce();

            gameObject.SetActive(false);
        }
    }
}
