using System;
using UnityEngine;

public class UnitAnimator : UnitComponent
{
	private Animator animator = null;

    private readonly int IsAttackHash = Animator.StringToHash("IsAttack");
    private readonly int IsMoveHash = Animator.StringToHash("IsMove");
    private readonly int IsDeathHash = Animator.StringToHash("IsDeath");
    private readonly int IsHitHash = Animator.StringToHash("IsHit");

    public event Action OnAnimationEndEvent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAttack(bool value)
    {
        animator.SetBool(IsAttackHash, value);
    }

    public void SetMove(bool value)
    {
        animator.SetBool(IsMoveHash, value);
    }

    public void SetDeath(bool value)
    {
        animator.SetBool(IsDeathHash, value);
    }

    public void SetHit(bool value)
    {
        animator.SetBool(IsHitHash, value);
    }

    public void OnAnimationEnd()
    {
        OnAnimationEndEvent?.Invoke();
    }
}
