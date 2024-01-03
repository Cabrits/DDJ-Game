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
        SpeedPowerup,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite(){

        switch(itemType){
            default:

            case ItemType.AmmoBuff: 
            return ItemAssets.Instance.ammoBuffSprite;

            case ItemType.BulletSpeedBuff: 
            return ItemAssets.Instance.bulletSpeedBuffSprite;

            case ItemType.DamagePowerup: 
            return ItemAssets.Instance.damagePowerupSprite;

            case ItemType.FireRateBuff: 
            return ItemAssets.Instance.fireRateBuffSprite;

            case ItemType.HealthPotion: 
            return ItemAssets.Instance.healthPotionSprite;

            case ItemType.ReloadSpeedBuff: 
            return ItemAssets.Instance.reloadSpeedBuffSprite;

            case ItemType.SpeedPowerup: 
            return ItemAssets.Instance.speedPowerupSprite;
        }
    }
}
