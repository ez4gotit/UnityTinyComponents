using UnityEngine;
using Global.Intefaces;

public class EntityComponent : MonoBehaviour, IEntity
{
    [SerializeField] private UnityEvent OnDie; 
    [SerializeField] private UnityEvent OnChangeHp; 
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
        OnChangeHp?.Invoke();
        return hp += amount;
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
