using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject mapScreenManager;
    public GameObject gameManager;

    private void Awake()
    {
        UpdateScore();
    }

    public void StartOver()
    {
        gameManager.GetComponent<GameManager>().Reset();
    }

    private void UpdateScore()
    {

    }
}
