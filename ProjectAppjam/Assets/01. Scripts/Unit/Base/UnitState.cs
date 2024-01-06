using UnityEngine;

public abstract class UnitState : MonoBehaviour
{
	protected UnitController controller;

    [field : SerializeField]
    public UnitStateType StateType { get; private set; }

    public virtual void Init(UnitController controller, UnitStateType stateType)
    {
        this.controller = controller;
        this.StateType = stateType;
    }

    public virtual void EnterState()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {

    }
}
