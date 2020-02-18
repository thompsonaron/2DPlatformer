using UnityEngine;
using System.Collections;
public class ScriptToAnimate : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Run");
        }
    }
}