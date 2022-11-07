using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static int currentWave { get; set; }

    public static int currentPoints { get; set; }
    public static int currentGold { get; set; }
    public static int currentHealth { get; set; }

    public static float stagePoints { get; set; }
    public static int stageGold { get; set; }

    public static List<GameObject> allWeapons { get; set; }
    public static List<GameObject> allJetpacks { get; set; }
    public static List<GameObject> allBullets { get; set; }

    public static List<GameObject> ownedWeapons { get; set; }
    public static List<GameObject> ownedJetpacks { get; set; }
    public static List<GameObject> ownedBullets { get; set; }

    public static GameObject currentWeapon { get; set; }
    public static GameObject currentJetpack { get; set; }
    public static GameObject currentBullet { get; set; }

    public static int playerLives { get; set; }
    
    public static string playerName { get; set; }
}
