using UnityEngine;

public class MapScreenManager : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject storeScreen;
    public GameObject waveSpawner;
    public GameObject santa;

    public void ShowWinScreen()
    {
        gameScreen.SetActive(false);
        winScreen.SetActive(true);
        storeScreen.SetActive(false);
    }

    public void ShowStoreScreen()
    {
        gameScreen.SetActive(false);
        winScreen.SetActive(false);
        storeScreen.SetActive(true);
    }

    public void StartNextWave()
    {
        gameScreen.SetActive(true);
        winScreen.SetActive(false);
        storeScreen.SetActive(false);

        waveSpawner.GetComponent<WaveSpawner>().NextWave();
    }
}
