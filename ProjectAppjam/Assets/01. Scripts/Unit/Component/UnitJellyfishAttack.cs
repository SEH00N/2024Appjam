using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitJellyfishAttack : UnitAttack
{
    Collider collider;

    public override void ActiveAttack()
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z), 3f, targetLayer);
        Instantiate(particlePrefab, transform.position, Quaternion.identity).Play();

        foreach(var attackObj in attack)
        {
            collider = attackObj;
            attackObj.GetComponent<UnitMovement>().SetMoveable(false);
            attackObj.GetComponent<IDamageable>().OnDamaged(0, attackObj.gameObject, Vector3.zero);
            Instantiate(particlePrefab, attackObj.transform.position, Quaternion.identity).Play();

            StartCoroutine("AttackTimeCheck");
        }
    }

    IEnumerator AttackTimeCheck()
    {
        yield return new WaitForSeconds(2f);
        collider.GetComponent<UnitMovement>().SetMoveable(true);
    }
}
