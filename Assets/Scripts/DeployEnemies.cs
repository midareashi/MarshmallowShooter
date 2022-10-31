using System.Collections;
using UnityEngine;

public class DeployEnemies : MonoBehaviour
{
    public GameObject enemiesPrefab;
    public float respawnTime = 1.5f;
    public int enemiesLeft;
    public static int totalEnemies = 10;

    void Start()
    {
        var a = GameManager.CameraPosition;
        enemiesLeft = totalEnemies;
        StartCoroutine(EnemyWave());
    }

    private void SpawnEnemy()
    {
        GameObject a = Instantiate(enemiesPrefab);
        a.transform.position = new Vector2(Random.Range(-GameManager.CameraPosition.x + 6, GameManager.CameraPosition.x - 6), GameManager.CameraPosition.y * 1.5f);
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
