using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameName;
    public static int currentWave;
    public static int currentPoints;
    public static int highScore;
    public static int currentGold;
    public static int gameDifficulty;

    public static List<GameObject> allWeapons;
    public static List<GameObject> allJetpacks;
    public static List<GameObject> allBullets;
    public static List<GameObject> ownedWeapons;
    public static List<GameObject> ownedJetpacks;
    public static List<GameObject> ownedBullets;

    public static GameObject currentWeapon;
    public static GameObject currentJetpack;
    public static GameObject currentBullet;

    public void Reset()
    {
        gameName = "";
        currentWave = 0;
        currentPoints = 0;
        currentGold = 0;
        gameDifficulty = 0;

        allWeapons = null;
        allJetpacks = null;
        allBullets = null;
        ownedWeapons = null;
        ownedJetpacks = null;
        ownedBullets = null;

        currentWeapon = null;
        currentJetpack = null;
        currentBullet = null;
    }
}
