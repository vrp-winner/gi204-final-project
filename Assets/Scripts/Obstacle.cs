using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ConstantForce2D myConstantForce;
    private Rigidbody2D rb;

    void Start()
    {
        myConstantForce = GetComponent<ConstantForce2D>();
        rb = GetComponent<Rigidbody2D>();
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