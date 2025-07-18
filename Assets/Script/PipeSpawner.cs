using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnRate = .1f;
    public float RandomVariable = 1f;
    public Transform PrefabStart;
    
    private float timeBetweenPipes = float.MaxValue;

    void Update()
    {
        timeBetweenPipes += Time.deltaTime;
        if (timeBetweenPipes >= SpawnRate)
        {
            SpawnPipes();
            timeBetweenPipes = 0f;
        }
    }

    public void StartSpawning()
    {
        enabled = true;
    }

    void SpawnPipes()
    {
        float yOffset = Random.Range(-RandomVariable, RandomVariable);
        Vector3 spawnPosition = PrefabStart.position + Vector3.up * yOffset;
        Instantiate(Prefab, spawnPosition, Quaternion.identity);
    }
}
