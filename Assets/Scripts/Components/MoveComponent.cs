using UnityEngine;
using Global.Intefaces;
using System.Collections;
public class MoveComponent : MonoBehaviour, IMoveController
{
    #region Fields
    [SerializeField]private float _moveSpeed;
    [SerializeField]private float _rotationSpeed;
    [SerializeField]private float _jumpDuration = 1.5f;
    [SerializeField]private float _jumpHeight = 1.5f;
    public float moveSpeed { get => _moveSpeed; set => _moveSpeed=value; }
    public float rotationSpeed { get => _rotationSpeed; set => _rotationSpeed=value; }
    [SerializeField] private Rigidbody rigidBody;
    public bool canMove = true;
    public bool isGrounded = true;
    public float jumpVelocity = 5f;
    public float maxVelocityChange = 10f;
    public float gravityForce;
    public float groundCheckDistance;
    
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
        CheckGround();
        Vector3 targetVelocity = Vector3.down * gravityForce + (direction.x*transform.forward+direction.z*transform.right)*moveSpeed;//+ (isGrounded? direction.y*transform.up*jumpVelocity:Vector3.zero);
        Vector3 velocity = rigidBody.linearVelocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
    }
    //deltaY = currentY - initialY 
    //jumpVelocity, JumpHeight, jumpDuration
    //while delataY < JumpHeight && jumpDuration < Time.currentTime- jumpStartTime
    //{  }
    public void Jump()
    {
        if (rigidBody.linearVelocity.y > 0) isGrounded = false;
        if (isGrounded)
        {
            isGrounded = false;
            float jumpStart = Time.time;
            float initialY = transform.position.y;
            float dTime = jumpStart - Time.time;
            float dY = initialY - transform.position.y;
            while (dTime < _jumpDuration && dY < _jumpHeight)
            {
                rigidBody.AddForce(0f, jumpVelocity, 0f, ForceMode.Impulse);
            }
            
            //StartCoroutine(JumpCoroutine());
            
        }

    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = groundCheckDistance;

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
    private IEnumerator JumpCoroutine()
    {
        while (rigidBody.linearVelocity.y < jumpVelocity)
        {
            rigidBody.AddForce( 0,Time.deltaTime,0,ForceMode.VelocityChange);
            yield return null;
        }
    }
}
