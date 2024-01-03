using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory {
        
    public enum ItemType{
        AmmoBuff,
        BulletSpeedBuff,
        DamagePowerup,
        FireRateBuff,
        HealthPotion,
        ReloadSpeedBuff,
        SpeedPowerup
    }

    public ItemType itemType;
    public int amount;
}
