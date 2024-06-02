using UnityEngine;
using Global.Intefaces;
using System.Runtime.InteropServices.WindowsRuntime;
public class MoveController : MonoBehaviour, IMoveController
{

    private float _moveSpeed;
    private float _rotationSpeed;
    public float moveSpeed { get => _moveSpeed; set => moveSpeed=value; }
    public float rotationSpeed { get => _rotationSpeed; set => rotationSpeed=value; }
    
    public void MoveToward(Vector3 positionToMove)
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, positionToMove, moveSpeed);
    }
    public void RotateToward(Quaternion rotationToRotate)
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotationToRotate, rotationSpeed);
    }
}
