using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem particlePrefab;
    [SerializeField] protected float speed;
    public Sprite Sprite;
    protected Rigidbody rb;

    public LayerMask targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.one * Time.deltaTime * 720f * 2f);
    }

	public void SetDirection(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity).Play();
        OnCollision(other);
        Destroy(gameObject);
    }

    protected abstract void OnCollision(Collision other);
}
