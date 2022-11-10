using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text gold;

    private void Update()
    {
        score.text = GameManager.currentPoints.ToString() + " Points";
        gold.text = GameManager.currentGold.ToString() + " Gold";
    }
}
