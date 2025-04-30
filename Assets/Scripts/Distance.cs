using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private float score;
    
    public TextMeshProUGUI distanceText;
    private PlayerController playerController; // Reference ไปที่ PlayerController
    
    void Start()
    {
        // ค้นหา "Car" PlayerController มาใช้
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.GetIsGameOver())
        {
            score += Time.deltaTime * 5f;
            distanceText.text = "Distance " + Mathf.RoundToInt(score);
        }
    }
}