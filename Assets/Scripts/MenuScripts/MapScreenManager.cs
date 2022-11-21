using UnityEngine;

public class MapScreenManager : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject mainScreen;
    public GameObject scoreScreen;
    public GameObject waveSpawner;
    public GameObject helpScreen;

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
        santa.GetComponent<PlayerController>().bonusText = "";
        santa.GetComponent<PlayerController>().speedBonusTemp = 0;
        santa.GetComponent<PlayerController>().damageBonusTemp = 0;
    }

    public void ShowLoseScreen()
    {
        HideAllScreen();
        loseScreen.SetActive(true);
        scoreScreen.SetActive(true);
    }

    public void StartNextWave()
    {
        HideAllScreen();
        gameScreen.SetActive(true);
        scoreScreen.SetActive(true);
        santa.GetComponent<PlayerController>().hasBonus = false;
        santa.GetComponent<PlayerController>().bonusText = "";
        santa.GetComponent<PlayerController>().speedBonusTemp = 0;
        santa.GetComponent<PlayerController>().damageBonusTemp = 0;
        waveSpawner.GetComponent<WaveSpawner>().NextWave();
    }

    public void ShowStartScreen()
    {
        HideAllScreen();
        mainScreen.SetActive(true);
    }

    public void ShowHelpScreen()
    {
        HideAllScreen();
        helpScreen.SetActive(true);
    }

    private void HideAllScreen()
    {
        gameScreen.SetActive(false);
        winScreen.SetActive(false);
        mainScreen.SetActive(false);
        scoreScreen.SetActive(false);
        helpScreen.SetActive(false);
    }
}
