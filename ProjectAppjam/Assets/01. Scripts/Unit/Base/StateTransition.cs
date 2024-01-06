using UnityEngine;

public abstract class StateTransition : MonoBehaviour
{
	[field : SerializeField]
	public UnitStateType TargetStateType { get; private set; }

	public bool IsReverse;

	protected UnitController controller;
	protected UnitState currentState;

	public virtual void Init(UnitController controller, UnitState state)
	{
		this.controller = controller;
		this.currentState = state;
	}

	public abstract bool MakeCondition();
}
