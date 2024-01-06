using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform trm;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - trm.position;
    }

    private void FixedUpdate()
    {
        transform.position = offset + trm.position;
    }
}
