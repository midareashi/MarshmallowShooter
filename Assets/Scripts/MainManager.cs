using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int currentWave;

    public int currentPoints;
    public int currentGold;

    public int stagePoints;
    public int StageGold;

    public GameObject currentJetpack;
    public GameObject currentWeapon;
    public GameObject currentBullet;
    public int currentHealth;
    public List<GameObject> ownedJetpacks;
    public List<GameObject> ownedWeapons;
    public List<GameObject> ownedBullets;
    public int currentLives;

    // Update is called once per frame
    void Update()
    {
        
    }

    public static MainManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
