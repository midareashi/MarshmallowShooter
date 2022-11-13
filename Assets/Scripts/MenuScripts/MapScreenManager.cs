using UnityEngine;

public class MapScreenManager : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject storeScreen;
    public GameObject mainScreen;
    public GameObject scoreScreen;
    public GameObject waveSpawner;
    public GameObject santa;
    public GameObject dirtTile;

    private void Awake()
    {
        HideAllScreen();
        mainScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        HideAllScreen();
        winScreen.SetActive(true);
        scoreScreen.SetActive(true);
        santa.GetComponent<PlayerController>().hasBonus = false;
    }

    public void ShowStoreScreen()
    {
        HideAllScreen();
        storeScreen.SetActive(true);
        scoreScreen.SetActive(true);
    }

    public void StartNextWave()
    {
        HideAllScreen();
        gameScreen.SetActive(true);
        scoreScreen.SetActive(true);
        dirtTile.GetComponent<DirtTile>().MakeNewMap();
        santa.GetComponent<PlayerController>().hasBonus = false;
        waveSpawner.GetComponent<WaveSpawner>().NextWave();
    }

    public void ShowStartScreen()
    {
        HideAllScreen();
        mainScreen.SetActive(true);
    }

    private void HideAllScreen()
    {
        gameScreen.SetActive(false);
        winScreen.SetActive(false);
        storeScreen.SetActive(false);
        mainScreen.SetActive(false);
        scoreScreen.SetActive(false);
    }
}
