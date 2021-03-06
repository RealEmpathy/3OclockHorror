﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Inventory myInv;
    [SerializeField]
    GameObject cntnrDisp;
    [SerializeField]
    InventoryManager IM;
    [SerializeField]
    float interactDist;
    bool active; //Am I the active workbench inventory?

    // Start is called before the first frame update
    void Start()
    {
        if (myInv == null)
        {
            myInv = gameObject.GetComponent<Inventory>();
        }
        if(interactDist == 0f)
        {
            interactDist = 0.25f;
        }
        active = false;
        myInv.CloseInv();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position); //Get the position of player
        if (dist <= interactDist) //If the player is in range
        {
            if (Input.GetKeyDown("e") && !active)
            {
                IM.ActivateInventory(myInv);
                myInv.OpenInv();
                active = true;
                cntnrDisp.SetActive(true);
            }
            else if (Input.GetKeyDown("e") && active)
            {
                IM.DeactivateInventory(myInv);
                active = false;
                cntnrDisp.SetActive(false);
            }
        }
    }
}
