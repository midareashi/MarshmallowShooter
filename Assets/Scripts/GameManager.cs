using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string gameName;
    public static int currentWave;
    public static int currentPoints;
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
}
