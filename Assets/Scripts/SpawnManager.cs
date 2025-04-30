using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;
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
        float randomValue = Random.value;
        while (!playerController.GetIsGameOver())
        {        
            int firstSpawnIndex = Random.Range(0, spawnPoint.Length);
            int secondSpawnIndex;
            do
            {
                secondSpawnIndex = Random.Range(0, spawnPoint.Length);
            } while (secondSpawnIndex == firstSpawnIndex);

            int randomIndex = Random.Range(0, obstaclePrefab.Length);          
            Instantiate(obstaclePrefab[randomIndex], spawnPoint[firstSpawnIndex].position, Quaternion.identity);
            Instantiate(obstaclePrefab[randomIndex], spawnPoint[secondSpawnIndex].position, Quaternion.identity);

            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
