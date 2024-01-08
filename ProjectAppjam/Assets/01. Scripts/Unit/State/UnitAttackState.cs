using System;
using UnityEngine;

public class UnitAttackState : UnitState
{
	private float lastAttackTime;
    private float attackDelay;

    private UnitAttack attack;

    public override void Init(UnitController controller, UnitStateType stateType)
    {
        base.Init(controller, stateType);
        attack = controller.GetUnitComponent<UnitAttack>(UnitComponentType.Attack);
        attackDelay = controller.UnitData.AttackDelay;
    }

    public override void EnterState()
    {
        base.EnterState();
        lastAttackTime = Time.time - attackDelay * 0.5f;
        controller.Ainmator.SetMove(false);
        controller.Ainmator.OnAnimationEndEvent += HandleAnimationEnd;
    }

    public override void ExitState()
    {
        base.ExitState();
        controller.Ainmator.OnAnimationEndEvent -= HandleAnimationEnd;        
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(Time.time - lastAttackTime < attackDelay)
            return;

        lastAttackTime = Time.time;
        controller.Ainmator.SetMove(false);
        controller.Ainmator.SetAttack(true);
    }

    private void HandleAnimationEnd()
    {
        attack.ActiveAttack();
        controller.Ainmator.SetAttack(false);
    }
}
