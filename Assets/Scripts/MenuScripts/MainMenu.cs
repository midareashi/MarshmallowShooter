using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text textCharacterLimit;
    public GameObject mapScreenManager;
    public int nameCharacterLimit;

    private void Awake()
    {
        textCharacterLimit.text = "Limit " + nameCharacterLimit.ToString() + " Characters";
        if (PlayerPrefs.GetString("Name") != "")
        {
            nameInput.text = PlayerPrefs.GetString("Name");
        }
    }

    public void NextWave()
    {
        if (nameInput.text != "" && nameInput.text.Length <= nameCharacterLimit)
        {
            mapScreenManager.GetComponent<MapScreenManager>().StartNextWave();
            PlayerPrefs.SetString("Name", nameInput.text);
        }
    }
}
