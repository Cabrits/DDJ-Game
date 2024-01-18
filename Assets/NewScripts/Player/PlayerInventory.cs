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
        }
    }

    public void SaveSceneKeepValue(){
        StaticData.itemList = inventory.GetItemList();
    }

    public void LoadSceneKeepValue(){
        Debug.Log("I'mHERE");
        inventory.SetItemList(StaticData.itemList);
    }
}
