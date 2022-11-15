using UnityEngine;
using TMPro;
using System;

public class WinScreen : MonoBehaviour
{
    public GameObject mapScreenManager;
    public TMP_Text congrats;

    private void Start()
    {
        congrats.text = String.Format(@"Congratulations, you have completed stage {0}. Continue to the next stage.", (GameManager.currentWave).ToString());
    }

    public void NextWave()
    {
        mapScreenManager.GetComponent<MapScreenManager>().StartNextWave();
    }

    public void GoToStore()
    {
        mapScreenManager.GetComponent<MapScreenManager>().ShowStoreScreen();
    }
}
