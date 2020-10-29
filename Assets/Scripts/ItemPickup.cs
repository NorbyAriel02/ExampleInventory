using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interacted()
    {
        base.Interacted();
        Pickup();
    }

    private void Pickup()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPuckedup = Inventory.instance.Add(item);
        if (wasPuckedup)
            Destroy(gameObject);
    }
}
