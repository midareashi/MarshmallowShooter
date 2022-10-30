using System.Collections;
using UnityEngine;

public class DeployEnemies : MonoBehaviour
{
    public GameObject enemiesPrefab;
    public float respawnTime = 1.0f;
    public int enemiesLeft;
    public static int totalEnemies = 5;

    void Start()
    {
        var a = GameManager.CameraPosition;
        enemiesLeft = totalEnemies;
        StartCoroutine(EnemyWave());
    }

    private void SpawnEnemy()
    {
        GameObject a = Instantiate(enemiesPrefab);
        a.transform.position = new Vector2(Random.Range(-GameManager.CameraPosition.x, GameManager.CameraPosition.x), GameManager.CameraPosition.y * 2);
    }

    IEnumerator EnemyWave()
    {
        while (enemiesLeft > 0)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
            //enemiesLeft--;
        }
    }
}
