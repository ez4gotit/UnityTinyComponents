using UnityEngine;
namespace Global.Intefaces
{
    public interface IEntity
    {
        float hp { get; set; }
        float ChangeHp(float amount);
        void Die();
    }
}