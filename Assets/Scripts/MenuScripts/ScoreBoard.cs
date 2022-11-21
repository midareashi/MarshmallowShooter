using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    public TMP_Text bonus;
    public GameObject santa;
    private PlayerController santaPC;

    private void Awake()
    {
        santaPC = santa.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (GameManager.currentPoints > GameManager.highScore)
        {
            GameManager.highScore = GameManager.currentPoints;
        }
        score.text = "Score: " + GameManager.currentPoints.ToString("0.0");
        highScore.text = "High Score: " + GameManager.highScore.ToString("0.0");
        bonus.text = GetSantaBonus();
    }

    private string GetSantaBonus()
    {
        string bonus = "";
        if (santaPC.bonusText != "")
        {
            bonus += santaPC.bonusText + " for " + (santaPC.bonusTimeDuration + santaPC.bonusStartTime - Time.time).ToString("0.0") + " more seconds!";
        }
        return bonus;
    }
}
