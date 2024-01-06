using UnityEngine;

public class UnitIdleState : UnitState
{
    public override void EnterState()
    {
        base.EnterState();
        controller.ChangeState(UnitStateType.Patrol);
    }
}
