using UnityEngine;

public class UnitPatrolState : UnitState
{
	private Vector3 targetPosition;
    private UnitMovement movement;
    private float patrolDelay;
    private float sightDistance;

    private bool isStopped = false;

    public override void Init(UnitController controller, UnitStateType stateType)
    {
        base.Init(controller, stateType);
        movement = controller.GetUnitComponent<UnitMovement>(UnitComponentType.Movement);

        patrolDelay = controller.UnitData.PatrolDelay;
        sightDistance = controller.UnitData.SightDistance;
    }

    public override void EnterState()
    {
        base.EnterState();

        DoPatrol();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(isStopped == false && (targetPosition - controller.transform.position).sqrMagnitude < 0.5f)
        {
            isStopped = true;
            movement.StopImmediately();
            controller.DelayCallback(patrolDelay, DoPatrol);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        movement.StopImmediately();
    }

    private void DoPatrol()
    {
        targetPosition = controller.transform.position + Random.insideUnitSphere * sightDistance;
        movement.SetTargetPosition(targetPosition);
        isStopped = false;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if(UnityEditor.Selection.activeGameObject != gameObject)
            return;

        if (controller == null)
            return;

        Color prevColor = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controller.transform.position, targetPosition);
        Gizmos.color = prevColor;
    }
    #endif
}
