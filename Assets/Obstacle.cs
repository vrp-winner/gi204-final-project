using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ConstantForce2D force;
    void Start()
    {
        force = GetComponent<ConstantForce2D>();
    }

    public void StopObstacle()
    {
        if (force != null)
        {
            force.force = Vector2.zero;
        }
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
