using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;
    private bool isCollected;

    public GameObject pickupEffect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                isCollected = true;
                
                LevelManager.instance.gemsCollected++;
                UIController.instance.UpdateGemCountDisplay();
                Destroy(gameObject);
                Instantiate(pickupEffect, this.transform.position, this.transform.rotation);
                AudioManager.instance.PlaySFX(6);
            }
            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, this.transform.position, this.transform.rotation);
                    AudioManager.instance.PlaySFX(7);
                }
            }
        }
    }
}
