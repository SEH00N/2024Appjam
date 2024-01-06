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
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(Time.time - lastAttackTime < attackDelay)
            return;

        lastAttackTime = Time.time;
        attack.ActiveAttack();
    }
}
