using Unity.VisualScripting;
using UnityEngine;

public class UnitMovement : UnitComponent
{
    private Quaternion targetRotation;
	private Vector3 targetPosition;
    private Vector3 moveDir;

    private float moveSpeed;
    private float rotateSpeed;

    private bool isArrived = false;

    private bool canMove = false;

    public override void Init(UnitController controller)
    {
        base.Init(controller);

        moveSpeed = controller.UnitData.MoveSpeed;
        rotateSpeed = controller.UnitData.RotateSpeed;
    }

    private void FixedUpdate()
    {
        if(canMove == false)
            return;

        if(isArrived)
            return;
        
        Rotate();
        Move();
    }

    private void Move()
    {
        Vector3 moveVector = moveDir * moveSpeed * Time.fixedDeltaTime;
        transform.position += moveVector;
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotateSpeed);
    }

    public void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;

        Vector3 dir = targetPosition - transform.position;
        moveDir = dir.normalized;

        targetRotation = Quaternion.LookRotation(moveDir);
        isArrived = (dir.sqrMagnitude < 0.1f);
    }

    public void MoveImmediately(Vector3 pos)
    {
        SetTargetPosition(pos);
        transform.position = pos;
    }

    public void StopImmediately()
    {
        MoveImmediately(transform.position);
    }

    public void SetMoveable(bool value)
    {
        canMove = value;
    }
}
