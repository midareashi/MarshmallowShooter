using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public TMP_InputField nameInput;
    [SerializeField] public bool debug;

    private void Awake()
    {
        if (debug)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayGame()
    {
        if (nameInput.text != "")
        {
            GameManager.gameName = nameInput.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
