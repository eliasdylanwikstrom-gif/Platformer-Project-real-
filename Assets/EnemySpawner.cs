/*using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] Transform[] spawnPoints;
    [SerializeField] int spawnAmount = 1;
    [SerializeField] float spawnRadius = 3.0f;
    [SerializeField] Transform[] spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnpoint = spawnPoints[spawnIndex];

            Vector2 spawnOffset = Vector2.zero;
            spawnOffset.x = Random.Range(-spawnRadius, spawnRadius);
            spawnOffset.y = Random.Range(-spawnRadius, spawnRadius);
            Instantiate(enemyPrefab, spawnpoint.position + new Vector3(spawnOffset.x, spawnOffset.y, 0), Quaternion.identity);
        }
        foreach (Transform t in spawnPoints)
        { 
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }

    }
}*/
