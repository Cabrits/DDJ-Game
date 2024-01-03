using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory {
    
    public enum ItemType{
        Sword,
        HealthPotion,
        ManaPotion,
        Coin,
        Medkit,
    }

    public ItemType itemType;
    public int amount;
}
