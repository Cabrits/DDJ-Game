using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private UI_Inventory inventoryUI;
    void Start()
    {
        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);
        if(gameObject.scene.name != "Level 1" && gameObject.scene.name != "Tutorial" && gameObject.scene.name != "Tutorial 1"){
            LoadSceneKeepValue();
            Debug.Log("Loading Inventory");
        }
    }

    public void SaveSceneKeepValue(){
        StaticData.itemList = inventory.GetItemList();
        Debug.Log("Saving Inventory");
    }

    public void LoadSceneKeepValue(){
        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);
        inventory.SetItemList(StaticData.itemList);
    }
}
