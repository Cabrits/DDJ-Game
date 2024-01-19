using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {

    public event EventHandler OnItemListChanged;

    private List<ItemInventory> itemList;

    public Inventory (){
        itemList = new List<ItemInventory>();

        //AddItem(new ItemInventory {itemType = ItemInventory.ItemType.AmmoBuff, amount = 1});
        //AddItem(new ItemInventory {itemType = ItemInventory.ItemType.BulletSpeedBuff, amount = 1});
        //AddItem(new ItemInventory {itemType = ItemInventory.ItemType.FireRateBuff, amount = 1});
        //Debug.Log(itemList.Count);
    }

    
    public void AddItem(ItemInventory item){
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(ItemInventory item){
        itemList.Remove(item);
        GameObject player = GameObject.FindWithTag("Player");

        if(item.itemType.ToString() == "AmmoBuff"){
            Debug.Log("This is an Ammo Buff");
            player.GetComponent<PlayerGunStats>().maxAmmo -= 5;
        } else if(item.itemType.ToString() == "BulletSpeedBuff"){
            Debug.Log("This is an Bullet Speed Buff");
            player.GetComponent<PlayerGunStats>().bulletForce -= 5;
        } else if(item.itemType.ToString() == "DamagePowerup"){
            Debug.Log("This is an Damage Buff");
            player.GetComponent<PlayerGunStats>().gunDamage -= 10;
        } else if(item.itemType.ToString() == "FireRateBuff"){
            Debug.Log("This is an Fire Rate Buff");
            player.GetComponent<PlayerGunStats>().fireRate -= 10;
        } else if(item.itemType.ToString() == "ReloadSpeedBuff"){
            Debug.Log("This is an Reload Speed Buff");
            player.GetComponent<PlayerGunStats>().reloadSpeed += (float) 0.4;
        } else if(item.itemType.ToString() == "SpeedPowerup"){
            Debug.Log("This is an Speed Buff");
            player.GetComponent<PlayerStats>().playerSpeed -= (float) 3.29;
        }

        player.GetComponent<PlayerGrowth>().Shrink(player);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemInventory> GetItemList(){
        return itemList;
    }

    public void SetItemList(List<ItemInventory> listofitem){
        itemList = listofitem;
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
}
