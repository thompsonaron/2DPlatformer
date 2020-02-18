﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch;

    private SpriteRenderer theSr;

    public Sprite downSprite;

    private bool hasSwitched;

    public bool deactivateOnSwitch;

    // Start is called before the first frame update
    void Start()
    {
        theSr = GetComponent<SpriteRenderer>();
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (deactivateOnSwitch)
            {
                objectToSwitch.SetActive(false);

            }
            else
            {
                objectToSwitch.SetActive(true);
            }


            theSr.sprite = downSprite;
            hasSwitched = true;
        }
    }
}
