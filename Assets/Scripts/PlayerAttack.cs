using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatisEnemies;
    public float attackRange;
    public int damage;
    public Vector3 attackSize;

    private void Update()
    {
        // Debug.Log("WTF");
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                // TODO INSERT SCREEN SHAKE and attack anim
                GetComponent<Animator>().SetTrigger("Attack");
               
               
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, attackSize, 0f, whatisEnemies);
                if (enemiesToDamage.Length > 0)
                {
                    AudioManager.instance.PlaySFX(1);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        if (enemiesToDamage[i].GetComponent<EnemyController>())
                        {
                            enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(damage);
                        }
                        else if (enemiesToDamage[i].GetComponent<FlyingEnemyController>())
                        {
                            enemiesToDamage[i].GetComponent<FlyingEnemyController>().TakeDamage(damage);
                        }

                    }
                    
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, attackSize);
    }
}
