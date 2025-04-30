using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 100f;
    public bool isJumping = false;
    private bool isGameOver = false;
    
    private Rigidbody2D rb2d;

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGameOver) return;
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            GameManager.Instance.GameOver();
            
            rb2d.linearVelocity = Vector2.zero;
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            
            Obstacle obstacleScript = collision.gameObject.GetComponent<Obstacle>();
            if (obstacleScript != null)
            {
                obstacleScript.StopObstacle();
            }
        }
    }
}
