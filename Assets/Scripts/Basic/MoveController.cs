using UnityEngine;
using Global.Intefaces;
using System.Runtime.InteropServices.WindowsRuntime;
public class MoveController : MonoBehaviour, IMoveController
{

    private float _moveSpeed;
    private float _rotationSpeed;
    private Vector3 _positionToMove;
    private Quaternion _rotationToRotate;
    public float moveSpeed { get => _moveSpeed; set => moveSpeed= value; }
    public float rotationSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Vector3 positionToMove { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Quaternion rotationToRotate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    


    public void MoveToward()
    {
        //gameObject.transform.position = Vector3.MoveTowards();
    }
}
