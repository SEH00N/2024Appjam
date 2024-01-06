using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public float attackDelay;
    public float attackRange;
    public float interactRange;
    public float xRotateMove;
    public float yRotateMove;
    public float movementSpeed;
    public float rotateSpeed;

    public bool isAttack;
    public bool isAttackReady;
    public bool isInteract;

    public int damage;

    Rigidbody rigidbody;
    Animator animator;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
        Attack();
        Interact();
        Turn();
    }

    void GetInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        isAttack = Input.GetKey(KeyCode.Mouse0);
        isInteract = Input.GetKeyDown(KeyCode.F);
        xRotateMove = -Input.GetAxis("Mouse Y") * rotateSpeed;
        yRotateMove = Input.GetAxis("Mouse X") * rotateSpeed;
    }

    void Move()
    {
        transform.Translate(horizontalMove * movementSpeed, 0, verticalMove * movementSpeed);
        if (horizontalMove != 0 || verticalMove != 0) animator.SetBool("isSwimming", true);
        else animator.SetBool("isSwimming", false);
    }

    void Attack()
    {
        if (isAttack && isAttackReady)
        {
            isAttackReady = false;
            animator.SetTrigger("doAttack");
            Collider[] hit = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), attackRange);
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
            Collider[] interact = Physics.OverlapBox(transform.position, new Vector3(interactRange, interactRange, interactRange));
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

    void Turn()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yRotateMove += transform.eulerAngles.y;
        xRotateMove += transform.eulerAngles.x;

        transform.rotation = Quaternion.Euler(xRotateMove, yRotateMove, 0);
    }
}
