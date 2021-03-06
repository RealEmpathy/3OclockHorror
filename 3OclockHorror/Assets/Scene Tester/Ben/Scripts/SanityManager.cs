﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public float sanityValue; //Variable that holds how much sanity the player has

    public float timeLeft; // how long will the flick go for.
    public Material material; //reference to the sprite renderer
    public bool effectOn = false; //see if there is something playing
    private int currentlyPlaying = 0; // see what effect is playing currently
   
    public int[] effectCue = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // total of 11 slots going from 0 to 10 
    //cue list of effect that need to be be played next


    /*void Start()
    {
        //get reference from player's material
        material = GetComponent<SpriteRenderer>().material;
    }*/

    private void Update()
    {
        if (sanityValue <= 0)
        {
            Destroy(this.gameObject);
        }

        if (effectOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime; //countdown to turn off the effect.
            }
            if (timeLeft <= 0)
            {
                turnOffEffect(currentlyPlaying);
            }
        }

        if(effectCue[0] != 0 && effectOn == false)
        {
            playEffect(effectCue[0]);
            removeEffectCue();
        }
    }

    public void ChangeSanity(float changeValue)
    {
        sanityValue = sanityValue + changeValue;
        
        playEffect(1);//this calls the first effect, the red flicking lights
        //exemple for the future playEffect(1, 0.1); 
        //future iterations could have a second input to determine the shader effect intensity in the scene.
    }

    public void playEffect(int effectNumber)
    {
        if(!effectOn)
        {
            effectOn = true; //turning the bool on for the update calculation later
            switch (effectNumber)
            {
                case 1:
                    timeLeft = 10.0f;//setting for how long the effect will be active
                    material.SetFloat("_Flick", 0.4f); // activating the effect // the flick is at (0.4). Currently is can go from 0 to 0.4.
                    currentlyPlaying = 1;
                    break;

//-------------------------------------------------------------------------------------------------------

                case 2:// this slot is reserved for future effects
                    break;

//-------------------------------------------------------------------------------------------------------

                default://in case some something goes wrong
                    Debug.Log("The effect input is not in range the timer is set to 0 and no effects will play");
                    timeLeft = 0f;
                    break;
            }
        }
        else
        {
            if(effectNumber == currentlyPlaying || effectNumber == effectCue[0])
            {
                return;
            }
            else
            {
                arrangeEffectCue(effectNumber); // put the effect on the cue to be player later
            }
        }
        

    }

    public void turnOffEffect(int effectNumber)
    {
        effectOn = false; //turning the branch of calculation off after it's done
        switch (effectNumber) 
        {
            case 1:
                material.SetFloat("_Flick", 0);//setting the flick to zero and stopping the effect
                currentlyPlaying = 0;
                break;

//-------------------------------------------------------------------------------------------------------

            case 2:// this slot is reserved for future effects
                break;

//-------------------------------------------------------------------------------------------------------

            default://in case something goes wrong
                Debug.Log("The effect input is not in range the timer is set to 0 and no effects will play");
                timeLeft = 0;
                break;
        }

    }

    private void arrangeEffectCue(int effectNumber)
    {
        for(int i = 0; i < 10; i++)
        {
            if(effectCue[i] == 0)
            {
                effectCue[i] = effectNumber;
                break;
            }
        }
    }

    private void removeEffectCue()
    {
        for (int i = 0; i < 9; i++)
        {
            effectCue[i] = effectCue[i+1];
        }
        effectCue[10] = 0;
    }

}
