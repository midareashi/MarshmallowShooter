using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LoseScreen : MonoBehaviour
{
    public TMP_Text sorry;
    public GameObject santa;

    private void Start()
    {
        PlayerPrefs.SetInt("highScore", GameManager.highScore);
        santa.GetComponent<PlayerController>().hasBonus = false;

        sorry.text = String.Format(@"Sorry, I guess that baby penguin on stage {0} was just too tough for you :( Maybe next time you can get more than {1} points :)", (GameManager.currentWave).ToString(), GameManager.highScore.ToString());

        GameManager.currentPoints = 0;
        GameManager.currentWave = 0;
        GameManager.currentBullet = GameManager.allBullets[0];
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
