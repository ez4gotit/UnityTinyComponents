using UnityEngine;
using Global.Intefaces;
public class Movable : MonoBehaviour, IMovable
{
    Transform Transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RequestMove(Vector3 positionToMove)
    {
        gameObject.transform.position = positionToMove;
    }

    public void RequestRotation(Quaternion rotationToMove)
    {
        gameObject.transform.rotation = rotationToMove;

    }
}
