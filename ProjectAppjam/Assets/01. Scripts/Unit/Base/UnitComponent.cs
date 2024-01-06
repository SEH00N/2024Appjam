using UnityEngine;

public abstract class UnitComponent : MonoBehaviour
{
    private UnitController controller = null;

	public virtual void Init(UnitController controller)
    {
        this.controller = controller;
    }
}
