using Unity.Cinemachine;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    public bool enabled = true;
    public bool disabled = false;
    public GameObject item;

    public void enable()
    {
        if (!item.activeSelf)
        {
            item.SetActive(true);
            enabled = true;
        }
        
    }

    public void disable()
    {
        if (item.activeSelf)
        {
            // item.transform.position = new Vector3(9999, 9999, 9999);
            item.SetActive(false);
            disabled = true;
        }
    }
}