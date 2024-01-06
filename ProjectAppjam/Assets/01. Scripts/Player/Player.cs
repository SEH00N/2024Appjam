using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public float attackDelay;

    public bool isAttack;
    public bool isAttackReady;
    public bool isInteract;

    public int damage;

    void Update()
    {
        GetInput();
        Move();
        Attack();
        Interact();
    }

    void GetInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        isAttack = Input.GetKey(KeyCode.Mouse0);
        isInteract = Input.GetKeyDown(KeyCode.F);
    }

    void Move()
    {
        transform.Translate(horizontalMove * 0.2f, 0, verticalMove * 0.2f);
    }

    void Attack()
    {
        if (isAttack && isAttackReady)
        {
            isAttackReady = false;
            Collider[] hit = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 2);
            foreach (var hitObject in hit)
            {
                if (hitObject.gameObject.GetComponent<IDamageable>() is null) continue;
                
                hitObject.gameObject.GetComponent<IDamageable>().OnDamaged(damage, hitObject.gameObject, new Vector3(0, 0, 0));
            }
            StartCoroutine(AttackDelay());
        }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        isAttackReady = true;
    }

    void Interact()
    {
        if (isInteract)
        {
            GameObject nearObject = null;
            Collider[] interact = Physics.OverlapBox(transform.position, new Vector3(2, 2, 2));
            foreach (var interactObject in interact)
            {
                if (interactObject.gameObject.GetComponent<IInteractable>() is null) continue;

                if (nearObject is null)
                {
                    nearObject = interactObject.gameObject;
                }
                else
                {
                    if (Vector3.Distance(nearObject.transform.position, transform.position) > Vector3.Distance(interactObject.gameObject.transform.position, transform.position))
                    {
                        nearObject = interactObject.gameObject;
                    }
                }
            }
            if (nearObject is null) return;
            nearObject.GetComponent<IInteractable>().Interact(nearObject);
        }
    }
}
