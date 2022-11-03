using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;


    public void PlayGame()
    {
        
        if (nameInput.text != "")
        {
            MainManager.Instance.gameName = nameInput.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
