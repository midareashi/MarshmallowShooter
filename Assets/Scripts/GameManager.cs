using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 CameraPosition;

    void Awake()
    {
        CameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
}
