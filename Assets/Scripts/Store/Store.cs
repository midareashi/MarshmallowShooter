using UnityEngine;

public class BuyJetpack : MonoBehaviour
{
    [SerializeField] public GameObject jetpackHolder;

    private void Awake()
    {
        LoadInventory();
    }

    private void LoadInventory()
    {
        foreach (GameObject item in GameManager.allJetpacks)
        {

        }
    }
}
