using UnityEngine;

public class UnitChaseState : UnitState
{
    private UnitMovement movement;

    public override void Init(UnitController controller, UnitStateType stateType)
    {
        base.Init(controller, stateType);
        movement = controller.GetUnitComponent<UnitMovement>(UnitComponentType.Movement);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        movement.SetTargetPosition(controller.Target.position);
    }

    public override void ExitState()
    {
        base.ExitState();
        movement.StopImmediately();
    }
}
