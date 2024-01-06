using UnityEngine;

public abstract class StateTransition : MonoBehaviour
{
	[field : SerializeField]
	public UnitStateType TargetStateType {get; private set;}

	private UnitController controller;
	private UnitState currentState;

	public virtual void Init(UnitController controller, UnitState state)
	{
		this.controller = controller;
		this.currentState = state;
	}

	public abstract bool MakeCondition();
}
