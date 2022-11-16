using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Santa;
    private bool moveSantaToStart = false;
    private bool moveSantaOffScreen = false;

    public float speedBonusTemp;
    public int damageBonusTemp;

    public float bonusTimeDuration;
    public float bonusStartTime;
    public bool hasBonus;

    private void Awake()
    {
        hasBonus = false;
    }

    private void Update()
    {
        if (moveSantaOffScreen)
        {
            Santa.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 30, 0), 0.3f);
            if (Santa.transform.position == Vector3.MoveTowards(transform.position, new Vector3(0, 30, 0), 0.3f))
            {
                moveSantaOffScreen = false;
            }
        }

        if (moveSantaToStart)
        {
            Santa.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -15, 0), 0.3f);
            if (Santa.transform.position == Vector3.MoveTowards(transform.position, new Vector3(0, -15, 0), 0.3f))
            {
                moveSantaToStart = false;
                Santa.GetComponent<Boundries>().isBound = true;
            }
        }

        if (hasBonus)
        {
            ApplyBonus();
        }
    }

    public void FlyToStart()
    {
        moveSantaToStart = true;
    }

    private void ApplyBonus()
    {
        if (Time.time > bonusStartTime + bonusTimeDuration)
        {
            hasBonus = false;
            speedBonusTemp = 0;
            damageBonusTemp = 0;
        }
    }

    public void UpgradeEquipment()
    {
        foreach(GameObject item in GameManager.allWeapons)
        {
            if (item.GetComponent<PlayerWeapon>().upgradeWave == GameManager.currentWave)
            {
                GameManager.allWeapons.Select(x => { x.SetActive(false); return x;}).ToList();
                item.SetActive(true);
                break;
            }
        }

        foreach (GameObject item in GameManager.allJetpacks)
        {
            if (item.GetComponent<PlayerJetpack>().upgradeWave == GameManager.currentWave)
            {
                GameManager.allJetpacks.Select(x => { x.SetActive(false); return x; }).ToList();
                item.SetActive(true);
                break;
            }
        }
    }
}
