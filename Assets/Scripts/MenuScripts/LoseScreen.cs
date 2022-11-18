using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class LoseScreen : MonoBehaviour
{
    public TMP_Text sorry;
    public GameObject santa;

    private void Start()
    {
        PlayerPrefs.SetFloat("highScore", GameManager.highScore);
        santa.GetComponent<PlayerController>().hasBonus = false;

        sorry.text = String.Format(@"Sorry, I guess that baby penguin on stage {0} was just too tough for you :( Maybe next time you can get more than {1} points :)", (GameManager.currentWave).ToString(), GameManager.highScore.ToString());

        Destroy(GameObject.FindGameObjectsWithTag("Boss").Where(x => x.activeSelf).FirstOrDefault());
        Destroy(GameObject.FindGameObjectsWithTag("Enemy").Where(x => x.activeSelf).FirstOrDefault());
        GameManager.currentPoints = 0f;
        GameManager.currentWave = 0;
        GameManager.currentBullet = GameManager.allBullets[0];

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
