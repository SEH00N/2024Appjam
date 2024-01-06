using System.Collections;
using UnityEngine;

public class TurtleProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        if (1 << other.gameObject.layer != targetLayer)
            return;

        other.gameObject.GetComponent<IDamageable>()?.OnDamaged(1000, null, Vector3.zero);
    }

    IEnumerator AttackTimeCheck()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Collider>().GetComponent<UnitMovement>()?.SetMoveable(true);
    }
}
