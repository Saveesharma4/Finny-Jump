using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Pipe")]
    [SerializeField] private GameObject pipePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnRate = 1.8f;
    [SerializeField] private float heightOffset = 2f;

    private float spawnTimer;

    private bool canSpawn;

    private void Update()
    {
        if (!canSpawn)
            return;

        HandleSpawning();
    }

    public void BeginSpawning()
    {
        canSpawn = true;

        SpawnPipe();
    }

    private void HandleSpawning()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            SpawnPipe();

            spawnTimer = 0f;
        }
    }

    private void SpawnPipe()
    {
        float minY = transform.position.y - heightOffset;
        float maxY = transform.position.y + heightOffset;

        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            Random.Range(minY, maxY),
            0
        );

        Instantiate(
            pipePrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}