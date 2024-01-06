using System.Collections;
using UnityEngine;

public class TunaProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        if (1 << other.gameObject.layer != targetLayer)
            return;

        other.gameObject.GetComponent<IDamageable>()?.OnDamaged(1000, null, Vector3.zero);
        StartCoroutine(Bleeding(other.gameObject));
        StartCoroutine(Bleeding(other.gameObject));
        StartCoroutine(Bleeding(other.gameObject));
        StartCoroutine(Bleeding(other.gameObject));
    }

    IEnumerator Bleeding(GameObject attackObj)
    {
        attackObj.GetComponent<IDamageable>()?.OnDamaged(5, attackObj.gameObject, Vector3.zero);
        yield return new WaitForSeconds(1f);
    }
}
