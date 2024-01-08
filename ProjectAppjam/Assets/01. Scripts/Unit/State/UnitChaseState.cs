using UnityEngine;

public class UnitChaseState : UnitState
{
    private UnitMovement movement;

    public override void Init(UnitController controller, UnitStateType stateType)
    {
        base.Init(controller, stateType);
        controller.Ainmator.SetMove(true);
        movement = controller.GetUnitComponent<UnitMovement>(UnitComponentType.Movement);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        movement.SetTargetPosition(controller.Target.position);
        controller.Ainmator.SetMove(!movement.IsArrived);
    }

    public override void ExitState()
    {
        base.ExitState();
        controller.Ainmator.SetMove(false);
        movement.StopImmediately();
    }
}
