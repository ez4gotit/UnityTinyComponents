using UnityEngine;
namespace Global.Intefaces
{
    public interface IMovable
    {
        void RequestMove(Vector3 positionToMove);
        void RequestRotation(Quaternion rotationToMove);
    }
    public interface IMovableContainer
    {
        Vector3 positionToMove { get; set; }
        Quaternion rotationToRotate { get; set; }
    }
}