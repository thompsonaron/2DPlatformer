using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankMine : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Explode();

            PlayerHealthController.instance.DealDamage();

            AudioManager.instance.PlaySFX(3);
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }
}
