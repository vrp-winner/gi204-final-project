using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float leftBound;
    
    private ConstantForce2D myConstantForce;
    private Rigidbody2D rb;

    void Start()
    {
        myConstantForce = GetComponent<ConstantForce2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    public void StopObstacle()
    {
        if (GetComponent<ConstantForce>() != null)
        {
            GetComponent<ConstantForce>().force = Vector2.zero; // หยุดแรง
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; // หยุดการเคลื่อนที่
            rb.bodyType = RigidbodyType2D.Kinematic; // ป้องกันการเคลื่อนที่ต่อ
        }
    }
}