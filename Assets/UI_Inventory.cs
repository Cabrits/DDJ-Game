using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake(){
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        RefreshInventoryItems();
    }


    public void SetInventory(Inventory inventory){
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
        try {
            foreach(Transform child in itemSlotContainer) {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }
        

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 2.17f;

        foreach (ItemInventory item in inventory.GetItemList()){
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                //Debug.Log("Do Something!");
                inventory.RemoveItem(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if (x >= 4){
                x = 0;
                y--;
            }
        }
    } catch (Exception e){
            Debug.Log(e);
        }
    } 

}
