using UnityEngine;

public class JetpackManager : MonoBehaviour
{
    int totalJetpacks = 1;

    public GameObject jetpackHolder;

    public void Awake()
    {
        BuildJetpackList();
    }

    void Start()
    {
        MainManager.Instance.currentJetpack.SetActive(true);
    }

    void Update()
    {

    }

    public void PurchaseJetpack(GameObject purchaseJetpack)
    {

    }

    private void BuildJetpackList()
    {
        totalJetpacks = jetpackHolder.transform.childCount;
        MainManager.Instance.allJetpacks = new GameObject[totalJetpacks];

        for (int i = 0; i < totalJetpacks; i++)
        {
            MainManager.Instance.allJetpacks[i] = jetpackHolder.transform.GetChild(i).gameObject;
            MainManager.Instance.allJetpacks[i].SetActive(false);
        }

        MainManager.Instance.allJetpacks[0].SetActive(true);
        MainManager.Instance.currentJetpack = MainManager.Instance.allJetpacks[0];
    }
}
