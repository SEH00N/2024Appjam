using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitJellyfishAttack : UnitAttack
{
    Collider collider;

    public override void ActiveAttack()
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z), 3f, targetLayer);
        ParticleSystem instance = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        instance.Play();
        Destroy(instance, 1f);

        foreach(var attackObj in attack)
        {
            collider = attackObj;
            attackObj.GetComponent<UnitMovement>().SetMoveable(false);
            attackObj.GetComponent<IDamageable>().OnDamaged(10, attackObj.gameObject, Vector3.zero);

            StartCoroutine("AttackTimeCheck");
        }
    }

    IEnumerator AttackTimeCheck()
    {
        yield return new WaitForSeconds(2f);
        collider.GetComponent<UnitMovement>().SetMoveable(true);
    }
}
