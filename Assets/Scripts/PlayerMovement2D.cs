using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public CharacterController2D characterController2D;

    // Update is called once per frame
    void Update()
    {
        Input.GetAxisRaw("Horizontal");
    }
}
