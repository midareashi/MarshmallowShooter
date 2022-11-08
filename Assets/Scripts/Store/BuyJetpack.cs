using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject jetpackHolder;

    private void Awake()
    {
        var a = GameManager.allJetpacks;
        LoadInventory();
    }

    private void LoadInventory()
    {
        foreach (GameObject item in GameManager.allJetpacks)
        {
            Instantiate(item,jetpackHolder.transform);
        }
    }
}
