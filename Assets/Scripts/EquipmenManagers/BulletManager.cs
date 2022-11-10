using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletHolder;

    public void Awake()
    {
        if (GameManager.allBullets == null)
        {
            BuildBulletList();
        }
    }

    private void BuildBulletList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (PlayerBullet item in bulletHolder.GetComponentsInChildren<PlayerBullet>(true))
        {
            list.Add(item.bullet);
        }
        GameManager.allBullets = list;
        GameManager.ownedBullets = list;
        GameManager.currentBullet = list[0];

        Instantiate(GameManager.allBullets[0]);
    }
}
