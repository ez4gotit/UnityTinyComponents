using Unity.Cinemachine;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool isEnabled => item.activeSelf;
    public GameObject item;

    [SerializeField]
    public void Enable()
    {
        if (!item.activeSelf)
        {
            item.SetActive(true);
        }
        
    }

    public void Disable()
    {
        if (item.activeSelf)
        {
            // item.transform.position = new Vector3(9999, 9999, 9999);
            item.SetActive(false);
        }
    }
}