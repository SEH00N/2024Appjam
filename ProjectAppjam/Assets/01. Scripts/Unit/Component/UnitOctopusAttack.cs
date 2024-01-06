using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitOctopusAttack : UnitAttack
{
    public float ShakeAmount;
    float shakeTime;

    bool isShake;

    Vector3 initialPosition;

    Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if(isShake)
        camera.transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
    }

    public override void ActiveAttack()
    {
        initialPosition = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 3f);
        foreach (var attackObj in attack)
        {
            attackObj.GetComponent<IDamageable>().OnDamaged(0, attackObj.gameObject, Vector3.zero);
        }
            isShake = true;

        StartCoroutine("ShakeTimeCheck");
    }

    IEnumerator ShakeTimeCheck()
    {
        yield return new WaitForSeconds(2f);
        isShake = false;
        camera.transform.position = initialPosition;
    }
}

