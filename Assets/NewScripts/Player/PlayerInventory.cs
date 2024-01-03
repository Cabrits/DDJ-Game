using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory inventoryUI;
    void Start()
    {
           inventory = new Inventory();
           inventoryUI.SetInventory(inventory);
    }

    

}
