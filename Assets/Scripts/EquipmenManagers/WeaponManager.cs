using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weaponsHolder;

    public void Awake()
    {
        if (GameManager.allWeapons == null)
        {
            BuildWeaponList();
        }
    }

    private void BuildWeaponList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (PlayerWeapon item in weaponsHolder.GetComponentsInChildren<PlayerWeapon>(true))
        {
            list.Add(item.playerWpn);
        }
        GameManager.allWeapons = list;
        GameManager.ownedWeapons = list;
        GameManager.currentWeapon = list[0];
        GameManager.allWeapons[0].SetActive(true);
    }
}
