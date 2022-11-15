using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game Settings
    public static string gameName;
    public static int currentWave;
    public static int currentPoints;
    public static int highScore;
    public static int currentGold;
    public static int gameDifficulty;

    // Equipment Manager
    public static List<GameObject> allWeapons;
    public static List<GameObject> allJetpacks;
    public static List<GameObject> allBullets;

    public static List<GameObject> ownedWeapons;
    public static List<GameObject> ownedJetpacks;
    public static List<GameObject> ownedBullets;

    public static GameObject currentWeapon;
    public static GameObject currentJetpack;
    public static GameObject currentBullet;

    public GameObject weaponsHolder;
    public GameObject bulletsHolder;
    public GameObject jetpacksHolder;

    // Enemy Manager
    public static List<GameObject> allEnemies;

    public GameObject enemiesHolder;

    // Boss Manager
    public static List<GameObject> allBosses;

    public GameObject bossHolder;

    // Bonus Items
    public static List<GameObject> allBonuses;
    public GameObject bonusHolder;

    private void Awake()
    {
        BuildWeaponList();
        BuildJetpackList();
        BuildBulletList();
        BuildEnemyList();
        BuildBossList();
        BuildBonusList();

        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void BuildWeaponList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (PlayerWeapon item in weaponsHolder.GetComponentsInChildren<PlayerWeapon>(true))
        {
            list.Add(item.weapon);
        }
        allWeapons = list;
        ownedWeapons = list;
        currentWeapon = list[0];
        allWeapons[0].SetActive(true);
    }

    private void BuildJetpackList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (PlayerJetpack item in jetpacksHolder.GetComponentsInChildren<PlayerJetpack>(true))
        {
            list.Add(item.jetpack);
        }
        allJetpacks = list;
        ownedJetpacks = list;
        currentJetpack = list[0];
        allJetpacks[0].SetActive(true);
    }

    private void BuildBulletList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (PlayerBullet item in bulletsHolder.GetComponentsInChildren<PlayerBullet>(true))
        {
            list.Add(item.bullet);
        }
        allBullets = list;
        ownedBullets = list;
        currentBullet = list[0];

        Instantiate(allBullets[0]);
    }

    private void BuildEnemyList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Enemy item in enemiesHolder.GetComponentsInChildren<Enemy>(true))
        {
            list.Add(item.enemy);
        }
        allEnemies = list;

        foreach (GameObject enemy in allEnemies)
        {
            BuildSpawnList(enemy);
        }
    }

    public void BuildSpawnList(GameObject enemy)
    {
        List<Transform> list = new List<Transform>();
        foreach (Transform child in enemy.GetComponent<Enemy>().spawnHolder.transform)
        {
            list.Add(child);
        }
        enemy.GetComponent<Enemy>().spawnPoints = list;
    }

    public void BuildBossList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Boss item in bossHolder.GetComponentsInChildren<Boss>(true))
        {
            list.Add(item.boss);
        }
        allBosses = list;
    }

    public void BuildBonusList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Bonus item in bonusHolder.GetComponentsInChildren<Bonus>(true))
        {
            list.Add(item.bonus);
        }
        allBonuses = list;
    }
}
