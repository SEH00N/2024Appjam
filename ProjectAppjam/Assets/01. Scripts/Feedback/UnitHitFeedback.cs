using System;
using System.Collections;
using Base.Feedback;
using UnityEngine;

public class UnitHitFeedback : FeedbackBase
{
    private UnitMovement movement;
    private Rigidbody rb;

    private void Awake()
    {
        movement = transform.root.GetComponent<UnitMovement>();
        rb = transform.root.GetComponent<Rigidbody>();
    }

    public override void CreateFeedback()
    {
        movement.SetMoveable(false);
        rb.velocity = -rb.transform.forward * 5f;
        StartCoroutine(DelayCoroutine(0.5f, () => {
            movement.SetMoveable(true);
            rb.velocity = Vector3.zero;
        }));
    }

    public override void FinishFeedback()
    {
        StopAllCoroutines();
        movement.SetMoveable(true);
        rb.velocity = Vector3.zero;
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
