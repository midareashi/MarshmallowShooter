using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int currentWave;

    public int currentPoints;
    public int currentGold;
    public int currentHealth;

    public int stagePoints;
    public int StageGold;

    public GameObject currentWeapon;
    public GameObject currentJetpack;
    public GameObject currentBullet;

    public GameObject[] ownedWeapons;
    public GameObject[] ownedJetpacks;
    public GameObject[] ownedBullets;

    public GameObject[] allWeapons;
    public GameObject[] allJetpacks;
    public GameObject[] allBullets;

    public int currentLives;
    
    public string gameName;

    public static MainManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject, 2f);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
