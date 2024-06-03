using UnityEngine;
using Global.Tools;
public class PlayerComponentsController : MonoBehaviour
{

    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private EntityComponent entityComponent;
    [SerializeField] private InputComponent inputComponent;

    private void OnEnable()
    {
        moveComponent = gameObject.GetComponent<MoveComponent>();   
        entityComponent = gameObject.GetComponent<EntityComponent>();   
        inputComponent = gameObject.GetComponent<InputComponent>();   
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
        moveComponent.RotateToward(Quaternion.Euler(inputComponent.rotationAxis));
        
    }
}
