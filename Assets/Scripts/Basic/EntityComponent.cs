using UnityEngine;
using Global.Intefaces;
public class EntityComponent : MonoBehaviour, IEntity
{
    public float hp
    {
        get
        {
            return _hp;
        }
        set
        {
            if (value < 0) _hp = 0;
            else _hp = value;
        }
    }
    private float _hp;
    public float ChangeHp(float amount)
    {
        return hp += amount;
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }
}
