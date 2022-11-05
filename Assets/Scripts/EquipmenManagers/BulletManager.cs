using UnityEngine;

public class BulletManager : MonoBehaviour
{
    int totalBullets = 1;
    public GameObject bulletHolder;

    public void Awake()
    {
        BuildBulletList();
    }

    private void BuildBulletList()
    {
        totalBullets = bulletHolder.transform.childCount;
        MainManager.Instance.allBullets = new GameObject[totalBullets];

        for (int i = 0; i < totalBullets; i++)
        {
            MainManager.Instance.allBullets[i] = bulletHolder.transform.GetChild(i).gameObject;
            MainManager.Instance.allBullets[i].SetActive(false);
        }
        MainManager.Instance.currentBullet = Instantiate(MainManager.Instance.allBullets[0]);
    }
}
