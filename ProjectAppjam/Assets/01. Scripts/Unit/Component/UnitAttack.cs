using UnityEngine;

public abstract class UnitAttack : UnitComponent
{
	[SerializeField] protected LayerMask targetLayer;
	[SerializeField] protected ParticleSystem particlePrefab;
 
	public abstract void ActiveAttack();
}
