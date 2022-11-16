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
        score.text = "Score: " + GameManager.currentPoints.ToString();
        highScore.text = "High Score: " + GameManager.highScore.ToString();
        bonus.text =  GetSantaBonus();
    }

    private string GetSantaBonus()
    {
        string bonus = "";
        if (santaPC.hasBonus)
        {
            if (santaPC.speedBonusTemp > 0)
            {
                bonus = santaPC.speedBonusTemp.ToString() + " Bonus Speed";
            }
            if (santaPC.damageBonusTemp > 0)
            {
                bonus = santaPC.damageBonusTemp.ToString() + " Bonus Damage";
            }
            if (bonus != "")
            {
                bonus += " for " + (santaPC.bonusTimeDuration + santaPC.bonusStartTime - Time.time).ToString("0.0") + " more seconds!";
            }
}
        return bonus;
    }
}
