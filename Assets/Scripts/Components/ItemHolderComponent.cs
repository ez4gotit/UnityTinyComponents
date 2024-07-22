using Mirror.Examples.AdditiveLevels;
using UnityEngine;
[RequireComponent(typeof(InputComponent))]
[RequireComponent(typeof(InventoryComponent))]
public class ItemHolderComponent : MonoBehaviour
{
    [SerializeField] private float collectDistance;
    [SerializeField] private LayerMask collectableLayers;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject[] objectsToDisable;
    [SerializeField] private Transform hand;
    [SerializeField] private ItemController activeItem;
    [SerializeField] private InventoryComponent inventory;


    public void TryPickupItem()
    {
        try
        {
            PickUp();
        }
        catch
        {
            Debug.Log("Error");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        activeItem.gameObject.transform.position = hand.transform.position;
    }

    private void SetActiveItem(ItemController item)
    {

        activeItem.Disable();
        activeItem = item;
        item.Enable();
    }

    public void TryDropItem()
    {
        try
        {
            inventory.DropItem(activeItem);
        }
        catch
        {
            Debug.Log("Error");
        }
    }


    private void PickUp()
    {
        RaycastHit hit;
        Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, collectDistance, collectableLayers);
        inventory.Collect(hit.transform.gameObject.GetComponent<ItemController>());
    }
}
