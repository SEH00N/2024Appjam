using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform attackPosition;

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

    private bool onAttacking = false;

    Rigidbody rigidbody;
    private PlayerAnimator animator;    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = transform.Find("Visual").GetComponent<PlayerAnimator>();
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
        if(onAttacking)
            return;

        transform.Translate(horizontalMove * movementSpeed * Time.deltaTime, 0, verticalMove * movementSpeed * Time.deltaTime);

        if (horizontalMove != 0 || verticalMove != 0) 
            animator.SetMovement(true);
        else
            animator.SetMovement(false);
    }

    void Attack()
    {
        if (isAttack && isAttackReady)
        {
            onAttacking = true;
            isAttackReady = false;
            animator.SetMovement(false);
            animator.SetAttack(true);

            StartCoroutine(DelayCoroutine(0.45f, () => {
                onAttacking = false;
                animator.SetAttack(false);
             
                Collider[] hit = Physics.OverlapSphere(attackPosition.position, attackRange);
                foreach (var hitObject in hit)
                {
                    if (hitObject.gameObject.GetComponent<IDamageable>() is null) continue;
                    hitObject.gameObject.GetComponent<IDamageable>().OnDamaged(damage, hitObject.gameObject, new Vector3(0, 0, 0));
                }
            }));

            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
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
