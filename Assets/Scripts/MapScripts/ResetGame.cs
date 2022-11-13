using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject santa;

    public void Reset()
    {
        GameManager.currentWave = 0;
        GameManager.currentPoints = 0;
        GameManager.currentGold = 0;
        GameManager.gameDifficulty = 1;

        GameManager.allWeapons = null;
        GameManager.allJetpacks = null;
        GameManager.allBullets = null;
        GameManager.ownedWeapons = null;
        GameManager.ownedJetpacks = null;
        GameManager.ownedBullets = null;

        GameManager.currentWeapon = null;
        GameManager.currentJetpack = null;
        GameManager.currentBullet = null;

        santa.GetComponent<Vitals>().currentHealth = santa.GetComponent<Vitals>().maxHealth;
        santa.GetComponent<PlayerController>().speedBonusTemp = 0;
        santa.GetComponent<PlayerController>().damageBonusTemp = 0;
        santa.GetComponent<PlayerController>().hasBonus = false;
    }
}
