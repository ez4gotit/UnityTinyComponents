using UnityEngine;
using Global.Tools;
using Mirror;

public class PlayerComponentsController : NetworkBehaviour
{
    [Header("Internal Components")]
    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private EntityComponent entityComponent;
    [SerializeField] private InputComponent inputComponent;
    [SerializeField] private AnimationComponent animationComponent;
    [SerializeField] private InventoryComponent inventoryComponent;
    [SerializeField] private ItemHolderComponent itemHolderComponent;
    [Header("External Components")]
    [SerializeField] private MoveComponent headMoveComponent;
    [SerializeField] private MoveComponent torsoMoveComponent;

    private void OnEnable()
    {
        moveComponent = gameObject.GetComponent<MoveComponent>();   
        entityComponent = gameObject.GetComponent<EntityComponent>();   
        inputComponent = gameObject.GetComponent<InputComponent>();
        animationComponent = gameObject.GetComponent<AnimationComponent>();
        inventoryComponent = gameObject.GetComponent<InventoryComponent>();
        itemHolderComponent = gameObject.GetComponent<ItemHolderComponent>();
        headMoveComponent.rotationSpeed = moveComponent.rotationSpeed;
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        if (inputComponent.isAction) itemHolderComponent.TryPickupItem();
        if (inputComponent.isDrop) itemHolderComponent.TryDropItem();
    }

    private void FixedUpdate()
    {
        moveComponent?.MoveToward(Vectors.VectorConvert(inputComponent.inputAxis));
        moveComponent?.RotateToward(Quaternion.Euler(new Vector3(0,inputComponent.rotationAxis.y)));
        headMoveComponent?.RotateToward(Quaternion.Euler(new Vector3(inputComponent.rotationAxis.x,inputComponent.rotationAxis.y)));
        torsoMoveComponent?.RotateToward(Quaternion.Euler(new Vector3(inputComponent.rotationAxis.x,inputComponent.rotationAxis.y)));
        if (inputComponent.inputAxis.magnitude > 0)
        {
            animationComponent.PlayIfIdle("m_run", "m_idle_A");
            //animationComponent.transform.position = Vector3.down * 1.3f;
        }
        else
        {
            animationComponent.Play("m_idle_A");
            //animationComponent.transform.position = Vector3.down;
        }
        if (inputComponent.jumpState)moveComponent?.Jump();
    }
}
