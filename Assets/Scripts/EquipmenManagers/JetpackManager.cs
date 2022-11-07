using System.Collections.Generic;
using UnityEngine;

public class JetpackManager : MonoBehaviour
{
    public GameObject jetpackHolder;

    public void Awake()
    {
        if (GameManager.allJetpacks == null)
        {
            BuildJetpackList();
        }
    }

    private void BuildJetpackList()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Jetpack item in jetpackHolder.GetComponentsInChildren<Jetpack>(true))
        {
            list.Add(item.go);
        }
        GameManager.allJetpacks = list;
        GameManager.ownedJetpacks = list;
        GameManager.currentJetpack = list[0];
        GameManager.allJetpacks[0].SetActive(true);
    }
}
