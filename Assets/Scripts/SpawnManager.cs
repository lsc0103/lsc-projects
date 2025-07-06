using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public int maxEnemies = 5;
    public float spawnInterval = 3f;

    private float timer;

    void Update()
    {
        if (GameManager.Instance && !GameManager.Instance.IsPlaying)
            return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        int current = GameObject.FindObjectsOfType<EnemyAI>().Length;
        if (current >= maxEnemies)
            return;

        Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
        pos.y = transform.position.y;
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
