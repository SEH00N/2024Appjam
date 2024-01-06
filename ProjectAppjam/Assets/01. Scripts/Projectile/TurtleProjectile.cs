using System.Collections;
using UnityEngine;

public class TurtleProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        other.gameObject.GetComponent<IDamageable>().OnDamaged(30, other.gameObject, Vector3.zero);
    }

    IEnumerator AttackTimeCheck()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Collider>().GetComponent<UnitMovement>().SetMoveable(true);
    }
}
