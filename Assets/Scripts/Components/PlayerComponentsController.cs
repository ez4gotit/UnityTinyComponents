using UnityEngine;
using Global.Tools;
public class PlayerComponentsController : MonoBehaviour
{
    [Header("Internal Controllers")]
    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private EntityComponent entityComponent;
    [SerializeField] private InputComponent inputComponent;
    [Header("External Controllers")]
    [SerializeField] private MoveComponent headMoveComponent;

    private void OnEnable()
    {
        moveComponent = gameObject.GetComponent<MoveComponent>();   
        entityComponent = gameObject.GetComponent<EntityComponent>();   
        inputComponent = gameObject.GetComponent<InputComponent>();
        headMoveComponent.rotationSpeed = moveComponent.rotationSpeed;
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveComponent.MoveToward(Vectors.VectorConvert(inputComponent.inputAxis));
        moveComponent.RotateToward(Quaternion.Euler(new Vector3(0,inputComponent.rotationAxis.y)));
        headMoveComponent.RotateToward(Quaternion.Euler(new Vector3(inputComponent.rotationAxis.x,inputComponent.rotationAxis.y)));
        
    }
}
