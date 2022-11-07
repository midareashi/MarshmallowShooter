using UnityEngine;

public class MapScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject managerScreen;
    [SerializeField] public GameObject gameScreen;
    [SerializeField] public GameObject winScreen;
    [SerializeField] public GameObject storeScreen;
    [SerializeField] public WaveSpawner waveSpawner;

    private void Awake()
    {
    }

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

        waveSpawner.NextWave();
    }
}
