using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Item : MonoBehaviour{
    public ItemEffect itemEffect;

    private void OnTriggerEnter2D(Collider2D collision){

        GameObject player = collision.gameObject;
        
        if (player.TryGetComponent<PlayerStats>(out PlayerStats playerStats)) {
            if(itemEffect is HealthPotion){
                player.TryGetComponent<Health>(out Health health);
                if(health.currentHealth == health.maxHealth)
                {

                }
                else
                {
                    Destroy(this.gameObject);
                    itemEffect.Apply(player);
                }
            }
            else{
                Inventory inv = player.GetComponent<PlayerInventory>().inventory;
                if(itemEffect is SpeedBuff){   
                    inv.AddItem(new ItemInventory {itemType = ItemInventory.ItemType.SpeedPowerup, amount = 1});
                } else if(itemEffect is AmmoBuff){
                    inv.AddItem(new ItemInventory {itemType = ItemInventory.ItemType.AmmoBuff, amount = 1});

                } else if(itemEffect is BulletSpeedBuff){
                    inv.AddItem(new ItemInventory {itemType = ItemInventory.ItemType.BulletSpeedBuff, amount = 1});

                } else if(itemEffect is DamageBuff){
                    inv.AddItem(new ItemInventory {itemType = ItemInventory.ItemType.DamagePowerup, amount = 1});

                } else if(itemEffect is FireRateBuff){
                    inv.AddItem(new ItemInventory {itemType = ItemInventory.ItemType.FireRateBuff, amount = 1});

                } else if(itemEffect is ReloadSpeed){
                    inv.AddItem(new ItemInventory {itemType = ItemInventory.ItemType.ReloadSpeedBuff, amount = 1});

                }
                

                Destroy(this.gameObject);
                itemEffect.Apply(player);

                player.GetComponent<PlayerGrowth>().Grow(player);
                playerStats.powerUpCount += 1;
            }
        }
    }
}
