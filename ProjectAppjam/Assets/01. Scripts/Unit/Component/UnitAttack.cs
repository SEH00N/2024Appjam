using UnityEngine;

public abstract class UnitAttack : UnitComponent
{
	[SerializeField] protected LayerMask targetLayer;
 
	public abstract void ActiveAttack();
}
