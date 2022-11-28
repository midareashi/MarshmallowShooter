using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public TMP_Text sorry;
    public GameObject santa;

    private void Start()
    {
        PlayerPrefs.SetFloat("highScore", GameManager.highScore);
        santa.GetComponent<PlayerController>().hasBonus = false;
        santa.GetComponent<PlayerController>().bonusText = "";
        santa.GetComponent<PlayerController>().speedBonusTemp = 0;
        santa.GetComponent<PlayerController>().damageBonusTemp = 0;

        sorry.text = "I guess that baby penguin was just too tough for you :(";

        Destroy(GameObject.FindGameObjectsWithTag("Boss").Where(x => x.activeSelf).FirstOrDefault());
        Destroy(GameObject.FindGameObjectsWithTag("Enemy").Where(x => x.activeSelf).FirstOrDefault());
        GameManager.currentPoints = 0;
        GameManager.currentWave = 0;
        GameManager.bossSpawnCount = 0;
        GameManager.gameDifficulty = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
