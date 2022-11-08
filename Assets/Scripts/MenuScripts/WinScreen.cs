using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public GameObject mapScreenManager;

    public void NextWave()
    {
        mapScreenManager.GetComponent<MapScreenManager>().StartNextWave();
    }

    public void GoToStore()
    {
        mapScreenManager.GetComponent<MapScreenManager>().ShowStoreScreen();
    }
}
