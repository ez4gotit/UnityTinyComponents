using UnityEngine;

public class AnimationComponent : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public bool PlayIfIdle(string StateName, string IdleName = "idle")
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(IdleName))
        {
            animator.Play(StateName);
        }
        return false;
    }
    public void Play(string StateName)
    {

            animator.Play(StateName);

    }
}
