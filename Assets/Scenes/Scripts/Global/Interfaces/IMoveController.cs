using UnityEngine;
namespace Global.Intefaces
{
    public interface IMoveController
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        float moveSpeed { get; set; }
        float rotationSpeed { get; set; }
        void MoveToward(Vector3 positionToMove);
        void RotateToward(Quaternion rotationToRotate);

    }
}
