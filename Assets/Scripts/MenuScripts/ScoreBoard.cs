using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text gold;
    public TMP_Text bonus;
    public GameObject santa;
    private PlayerController santaPC;


    private void Awake()
    {
        santaPC = santa.GetComponent<PlayerController>();
    }

    private void Update()
    {
        score.text = GameManager.currentPoints.ToString() + " Points";
        gold.text = GameManager.currentGold.ToString() + " Gold";
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
