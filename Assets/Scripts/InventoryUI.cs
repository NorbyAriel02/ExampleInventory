using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    
    Inventory inventory;

    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for(int x = 0; x < slots.Length; x++)
        {
            if (x < inventory.items.Count)
            {
                slots[x].AddItem(inventory.items[x]);
            }
            else
                slots[x].ClearSlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
