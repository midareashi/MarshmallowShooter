using System;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text congrats;

    private void Awake()
    {
        congrats.text = String.Format(@"Congratulations, you have completed stage {0}. You can continute to stage {1} if you are ready, or you can visit the store to get stronger!",(MainManager.Instance.currentWave - 1).ToString(), MainManager.Instance.currentWave.ToString());
    }
}
