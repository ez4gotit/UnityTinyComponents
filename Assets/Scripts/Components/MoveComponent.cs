using UnityEngine;
using Global.Intefaces;
using System.Runtime.InteropServices.WindowsRuntime;
public class MoveComponent : MonoBehaviour, IMoveController
{
    #region Fields
    [SerializeField]private float _moveSpeed;
    [SerializeField]private float _rotationSpeed;
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed=value; }
    public float rotationSpeed { get => _rotationSpeed; set => _rotationSpeed=value; }
    [SerializeField] private Rigidbody rigidBody;
    public bool canMove = true;
    public bool isGrounded = true;
    public float jumpPower = 5f;
    public float maxVelocityChange = 10f;
    public float gravity;
    #endregion

    public void MoveToPoint(Vector3 positionToMove)
    {
        CheckGround();
        // Calculate how fast we should be moving
        Vector3 targetVelocity = (positionToMove - transform.position).normalized;

        // Checks if player is walking and isGrounded
        // Will allow head bob
        
        targetVelocity = transform.TransformDirection(targetVelocity) * moveSpeed;

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = rigidBody.linearVelocity;
        Vector3 velocityChange = (targetVelocity - velocity);


        rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);

    }

    public void MoveToward(Vector3 direction)
    {
        
        Vector3 targetVelocity = (direction.x*transform.forward+direction.z*transform.right)*moveSpeed;
        Vector3 velocity = rigidBody.linearVelocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        rigidBody.AddForce(velocityChange+Vector3.down, ForceMode.VelocityChange);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rigidBody.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .75f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void RotateToward(Quaternion rotationToRotate)
    {
        gameObject.transform.rotation = rotationToRotate;
        //rigidBody.angularVelocity = Vector3.zero;
    }
    
}
