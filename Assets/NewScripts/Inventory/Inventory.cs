using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {

    public event EventHandler OnItemListChanged;

    private List<ItemInventory> itemList;

    public Inventory (){
        itemList = new List<ItemInventory>();

        AddItem(new ItemInventory {itemType = ItemInventory.ItemType.AmmoBuff, amount = 1});
        AddItem(new ItemInventory {itemType = ItemInventory.ItemType.BulletSpeedBuff, amount = 1});
        AddItem(new ItemInventory {itemType = ItemInventory.ItemType.FireRateBuff, amount = 1});
        Debug.Log(itemList.Count);
    }

    
    public void AddItem(ItemInventory item){
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(ItemInventory item){
        
    }

    public List<ItemInventory> GetItemList(){
        return itemList;
    }
}
