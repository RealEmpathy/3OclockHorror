﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items", order = 1)]
public class Item : ScriptableObject
{
    //Name, icon, and descriptions
    public string ItemName; //Name of the Item
    public Sprite Icon; //The Item Icon
    public string desc; //A description of what the item is

    //Location Variables
    public bool rand;

    //Some specific stuff for different types of items
    #region Note
    [SerializeField]
    Item Key;
    [SerializeField]
    Item Amulet;

    public Inventory myInv;
    public bool Note;
    public bool isRead = false;
    public Item nextNote;
    public string text; //This is to hold the text for the note. Not meant to change. Desc is what will change.

    public void NextNoteInit() 
    {
        if (nextNote != null)
        {
            desc = text.Replace("***", nextNote.myInv.name);
            if(nextNote.myInv != null)
            {
                nextNote.myInv.AddStartingItem(nextNote);
            }
        }
        else if(nextNote == null && Key != null)
        {
            //Do key stuff
            if(Key.myInv != null && Amulet != null)
            {
                Key.myInv.AddStartingItem(Key);
                Amulet.myInv.AddStartingItem(Amulet);
                this.desc = text;
            }
        }
    }

    #endregion
    #region Key
    //Region for key specific data, if there is any
    #endregion
}
