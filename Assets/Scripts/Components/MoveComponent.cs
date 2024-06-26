using UnityEngine;
using Global.Intefaces;
using System.Collections;
using Unity.VisualScripting;
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
    [SerializeField] private float _jumpPower = 5f;
    [SerializeField] private float _currentJump = 0f;
    public float maxVelocityChange = 10f;
    public float gravityForce = 9.81f;
    [SerializeField] private float _groundCheckDistance = 0.8f;
    
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
        Vector3 targetVelocity = Vector3.down * gravityForce 
            + (direction.x*transform.forward+direction.z*transform.right)*moveSpeed
            + Vector3.up * _currentJump;//+ (isGrounded? direction.y*transform.up*jumpVelocity:Vector3.zero);
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
            StartCoroutine(JumpCoroutine(jumpStart, initialY));
            _currentJump = 0f;

        }

    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = _groundCheckDistance;

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
    private IEnumerator JumpCoroutine(float initialTime, float initialY)
    {
        while (Time.time - initialTime < _jumpDuration && transform.position.y - initialY < _jumpHeight)
        {
            _currentJump += _jumpPower;
            /*print(initialTime);
            print(Time.time);*/
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (_currentJump > 0)
        {
            _currentJump -= _jumpPower;
            /*print(initialTime);
            print(Time.time);*/
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _currentJump = 0f;
    }
}
