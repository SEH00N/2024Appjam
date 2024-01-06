using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private readonly int IsMoveHash = Animator.StringToHash("IsMove");
    private readonly int IsAttackHash = Animator.StringToHash("IsAttack");
    private readonly int IsDeadHash = Animator.StringToHash("IsDead");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMovement(bool value)
    {
        animator.SetBool(IsMoveHash, value);
    }

    public void SetAttack(bool value)
    {
        animator.SetBool(IsAttackHash, value);
    }

    public void SetDead(bool value)
    {
        animator.SetBool(IsDeadHash, value);
    }
}
