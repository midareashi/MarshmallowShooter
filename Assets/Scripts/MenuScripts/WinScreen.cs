using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text congrats;
    [SerializeField] public MapScreenManager msm;

    private void Awake()
    {
        congrats.text = String.Format(@"Congratulations, you have completed stage {0}. You can continute to stage {1} if you are ready, or you can visit the store to get stronger!",(GameManager.currentWave - 1).ToString(), GameManager.currentWave.ToString());
    }

    public void NextWave()
    {
        msm.StartNextWave();
    }

    public void GoToStore()
    {
        msm.storeScreen.SetActive(true);
    }
}
