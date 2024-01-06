using UnityEngine;

public class InnerDistanceTransition : StateTransition
{
    [SerializeField] float distance;
    private Transform target;

    public override void Init(UnitController controller, UnitState state)
    {
        base.Init(controller, state);
        target = controller.Target;
    }

    public override bool MakeCondition()
    {
        return ((target.position - controller.transform.position).magnitude < distance);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if(UnityEditor.Selection.activeGameObject != gameObject)
            return;
        
        if(controller == null)
            return;

        Color prevColor = Gizmos.color;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(controller.transform.position, distance);
        Gizmos.color = prevColor;
    }
    #endif
}
