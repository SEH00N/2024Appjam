using System.Collections.Generic;
using UnityEngine;

public abstract class UnitState : MonoBehaviour
{
	protected UnitController controller;

    [field : SerializeField]
    public UnitStateType StateType { get; private set; }

    private List<StateTransition> transitions;

    public virtual void Init(UnitController controller, UnitStateType stateType)
    {
        this.controller = controller;
        this.StateType = stateType;

        transitions = new List<StateTransition>();
        transform.GetComponentsInChildren<StateTransition>(transitions);
        transitions.ForEach(t => t.Init(controller, this));
    }

    public virtual void EnterState()
    {

    }

    public virtual void UpdateState()
    {
        transitions.ForEach(t => {
            if(t.MakeCondition())
                controller.ChangeState(t.TargetStateType);
        });
    }

    public virtual void ExitState()
    {

    }
}
