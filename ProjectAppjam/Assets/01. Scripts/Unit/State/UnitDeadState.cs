using UnityEngine;

public class UnitDeadState : UnitState
{
    public override void EnterState()
    {
        base.EnterState();
        controller.Ainmator.SetDeath(true);
    }
}
