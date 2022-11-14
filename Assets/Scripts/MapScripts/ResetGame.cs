using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject santa;
    public GameObject waveSpawner;

    public void Reset()
    {
        GameManager.currentWave = 0;
        GameManager.currentPoints = 0;
        GameManager.currentGold = 0;
        GameManager.gameDifficulty = 1;

        GameManager.ownedWeapons = null;
        GameManager.ownedJetpacks = null;
        GameManager.ownedBullets = null;

        GameManager.currentWeapon = GameManager.allWeapons[0];
        GameManager.currentJetpack = GameManager.allJetpacks[0];
        GameManager.currentBullet = GameManager.allBullets[0];

        santa.GetComponent<Vitals>().currentHealth = santa.GetComponent<Vitals>().maxHealth;
        santa.GetComponent<PlayerController>().speedBonusTemp = 0;
        santa.GetComponent<PlayerController>().damageBonusTemp = 0;
        santa.GetComponent<PlayerController>().hasBonus = false;
        santa.GetComponent<PlayerController>().FlyToStart();
    }
}
