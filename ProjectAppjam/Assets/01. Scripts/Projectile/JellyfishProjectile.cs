using UnityEngine;

public class JellyfishProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 3f);

        foreach (var attackObj in attack)
        {
            attackObj.GetComponent<UnitMovement>().SetMoveable(false);
            attackObj.GetComponent<IDamageable>().OnDamaged(0, attackObj.gameObject, Vector3.zero);
        }
    }
}
