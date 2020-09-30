﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items", order = 1)]
public class Item : ScriptableObject
{
    //Name, icon, and description
    public string ItemName;
    public Sprite Icon;
    public string desc;

    //Location Variables
    public bool rand;
}
