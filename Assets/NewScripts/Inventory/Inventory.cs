using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {

    public event EventHandler OnItemListChanged;

    private List<ItemInventory> itemList;

    public Inventory (){
        itemList = new List<ItemInventory>();

        AddItem(new ItemInventory {itemType = ItemInventory.ItemType.Sword, amount = 1});
        AddItem(new ItemInventory {itemType = ItemInventory.ItemType.HealthPotion, amount = 1});
        AddItem(new ItemInventory {itemType = ItemInventory.ItemType.ManaPotion, amount = 1});
        Debug.Log(itemList.Count);
    }

    
    public void AddItem(ItemInventory item){
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItemInventory> GetItemList(){
        return itemList;
    }
}
