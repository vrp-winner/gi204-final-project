using UnityEngine;

public class ObjectProjectile : MonoBehaviour
{
    public float leftBound;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 targetPosition = transform.position + new Vector3(-10, 0, 0);
        float flightTime = 0.35f;
        Vector2 projectileVelocity = CalculateProjectileVelocity(transform.position, targetPosition, flightTime);
        rb.linearVelocity = projectileVelocity;
    }
    
    void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
    
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
 
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
 
        return new Vector2(velocityX, velocityY);
    }
}
