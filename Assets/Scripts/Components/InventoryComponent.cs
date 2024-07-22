using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private Transform inventoryContainer;
    [SerializeField] private List<ItemController> StoredItems;
    public int Slots = 1;

    public void Collect(ItemController item)
    {
        if (StoredItems.Count < Slots)
        {
            StoredItems.Add(item);

            if (inventoryContainer != null)
            {
                item.gameObject.transform.position = inventoryContainer.transform.position;
            }
            item.transform.position = Vector3.one*-10000;
            item.Disable();
        }
        
    }

    public void DropItem(ItemController item)
    {
        if(StoredItems.Remove(item))
        {
            item.transform.position = gameObject.transform.position;
            item.Enable();
        }
    }

    public void DropAll()
    {
        foreach(var item in StoredItems)
        {
            item.transform.position = gameObject.transform.position;
            item.Enable();
        }
    }
}
