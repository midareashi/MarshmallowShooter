using UnityEngine;

public class JetpackManager : MonoBehaviour
{
    public GameObject jetpackHolder;
    int totalJetpacks = 1;

    public void Awake()
    {
        BuildJetpackList();
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
