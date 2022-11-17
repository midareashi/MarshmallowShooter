using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class WinScreen : MonoBehaviour
{
    public GameObject mapScreenManager;
    public TMP_Text congrats;
    private string upgradeMessage;

    private void OnEnable()
    {
        UpgradeEquipment();
        congrats.text = String.Format(@"Congratulations, you completed stage {0}. Continue to the next stage.{1}", (GameManager.currentWave).ToString(), upgradeMessage);
        Destroy(GameObject.FindGameObjectsWithTag("HealthUp").Where(x => x.activeSelf).FirstOrDefault());
        Destroy(GameObject.FindGameObjectsWithTag("PlayerBullet").Where(x => x.activeSelf).FirstOrDefault());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().FlyToStart();

    }

    public void NextWave()
    {
        mapScreenManager.GetComponent<MapScreenManager>().StartNextWave();
    }

    public void UpgradeEquipment()
    {
        upgradeMessage = "";
        foreach (GameObject item in GameManager.allWeapons)
        {
            if (item.GetComponent<PlayerWeapon>().upgradeWave == GameManager.currentWave)
            {
                GameManager.allWeapons.Select(x => { x.SetActive(false); return x; }).ToList();
                item.SetActive(true);
                upgradeMessage += " You recieve a new Weapon upgrade!";
                break;
            }
        }

        foreach (GameObject item in GameManager.allJetpacks)
        {
            if (item.GetComponent<PlayerJetpack>().upgradeWave == GameManager.currentWave)
            {
                GameManager.allJetpacks.Select(x => { x.SetActive(false); return x; }).ToList();
                item.SetActive(true);
                upgradeMessage += " You recieve a new Jetpack upgrade!";
                break;
            }
        }
    }
}
