using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{

    public List<GameObject> StoredItems;
    public int Slots = 1;

    public void Collect(GameObject item)
    {
        if (StoredItems.Count < Slots)
        {
            StoredItems.Add(item);


            item.transform.position = Vector3.one*-10000;
            item.SetActive(false);
        }
        
    }

    public void DropItem(GameObject item)
    {
        if(StoredItems.Remove(item))
        {
            item.transform.position = gameObject.transform.position;
            item.SetActive(true);
        }
    }

    public void DropAll()
    {
        foreach(var item in StoredItems)
        {
            item.transform.position = gameObject.transform.position;
            item.SetActive(true);
        }
    }
}
