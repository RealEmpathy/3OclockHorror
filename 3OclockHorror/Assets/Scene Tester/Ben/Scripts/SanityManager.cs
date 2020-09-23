﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public float sanityValue; //Variable that holds how much sanity the player has

    private void Update()
    {
        if(sanityValue <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeSanity(float changeValue)
    {
        sanityValue = sanityValue + changeValue;
    }
}
