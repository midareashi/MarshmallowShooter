using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WebPost : MonoBehaviour
{
    public void UpdateScore()
    {
        StartCoroutine(UpdateScoreboard());
    }

    IEnumerator UpdateScoreboard()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", PlayerPrefs.GetString("Name"));
        form.AddField("playerScore", GameManager.currentPoints);

        using (UnityWebRequest www = UnityWebRequest.Post("https://meetandgreet.yourcreativepeople.com/pages/coffeepunch/updatescoreboard.aspx", form))
        {
            yield return www.SendWebRequest();
        }
    }
}
