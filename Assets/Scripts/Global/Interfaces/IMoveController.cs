using UnityEngine;
namespace Global.Intefaces
{
    public interface IMoveController
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        float moveSpeed { get; set; }
        float rotationSpeed { get; set; }
        Vector3 positionToMove { get; set; }
        Quaternion rotationToRotate { get; set; }

    }
}
