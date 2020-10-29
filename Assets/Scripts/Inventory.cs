using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singlenton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!!");
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public int space = 1;
    public List<Item> items = new List<Item>();

    public bool Add(Item newItem)
    {
        if (!newItem.isDefaultItem)
        {
            if (items.Count > space)
            {
                Debug.Log("Inventory is Full");
                return false;
            }
            items.Add(newItem);

            if(onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item item) 
    {
        items.Remove(item);
        
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
