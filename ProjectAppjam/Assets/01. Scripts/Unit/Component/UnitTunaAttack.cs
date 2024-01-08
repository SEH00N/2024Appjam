using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTunaAttack : UnitAttack
{
    public override void ActiveAttack()
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 2f, targetLayer);
        foreach (var attackObj in attack)
        {
            if (attackObj.CompareTag("Player"))
            {
                attackObj.GetComponent<IDamageable>().OnDamaged(10, attackObj.gameObject, Vector3.zero);
                StartCoroutine(Bleeding(attackObj));
                StartCoroutine(Bleeding(attackObj));
                StartCoroutine(Bleeding(attackObj));
                StartCoroutine(Bleeding(attackObj));
            }
        }
    }

    IEnumerator Bleeding(Collider attackObj)
    {
        attackObj.GetComponent<IDamageable>().OnDamaged(5, attackObj.gameObject, Vector3.zero);
        yield return new WaitForSeconds(1f);
    }
}
