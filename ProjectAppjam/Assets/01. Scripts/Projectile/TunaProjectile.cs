using System.Collections;
using UnityEngine;

public class TunaProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        other.gameObject.GetComponent<IDamageable>().OnDamaged(20, other.gameObject, Vector3.zero);
        StartCoroutine(Bleeding(other.gameObject));
        StartCoroutine(Bleeding(other.gameObject));
        StartCoroutine(Bleeding(other.gameObject));
        StartCoroutine(Bleeding(other.gameObject));
    }

    IEnumerator Bleeding(GameObject attackObj)
    {
        attackObj.GetComponent<IDamageable>().OnDamaged(5, attackObj.gameObject, Vector3.zero);
        yield return new WaitForSeconds(1f);
    }
}
