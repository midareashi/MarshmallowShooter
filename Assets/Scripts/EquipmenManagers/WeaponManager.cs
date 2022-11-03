using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    int totalWeapons = 1;

    public GameObject weaponHolder;

    public void Awake()
    {
        BuildWeaponList();
    }

    void Start()
    {
        MainManager.Instance.currentWeapon.SetActive(true);
    }

    void Update()
    {
    }

    public void PurchaseWeapon(GameObject purchaseWeapon)
    {

    }

    private void BuildWeaponList()
    {
        totalWeapons = weaponHolder.transform.childCount;
        MainManager.Instance.allWeapons = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            MainManager.Instance.allWeapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            MainManager.Instance.allWeapons[i].SetActive(false);
        }

        MainManager.Instance.allWeapons[0].SetActive(true);
        MainManager.Instance.currentWeapon = MainManager.Instance.allWeapons[0];
    }
}
