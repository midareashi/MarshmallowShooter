using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weaponHolder;

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
        foreach (PlayerWeaponItem item in weaponHolder.GetComponentsInChildren<PlayerWeaponItem>(true))
        {
            list.Add(item.weaponItem);
        }
        GameManager.allWeapons = list;
        GameManager.ownedWeapons = list;
        GameManager.currentWeapon = list[0];
        GameManager.allWeapons[0].SetActive(true);
    }
}
