using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] obstaclePrefab;
    
    public float startDelay = 0.1f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 2f;
    
    private PlayerController playerController;
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke(nameof(StartSpawning), startDelay);
    }
    
    void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (!playerController.GetIsGameOver())
        {
            int randomIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[randomIndex], spawnPoint.position, Quaternion.identity);
            
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
