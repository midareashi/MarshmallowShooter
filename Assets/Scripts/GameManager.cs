using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 CameraPosition;

    void Awake()
    {
        CameraPosition =  GetCameraPosition();
    }

    public Vector2 GetCameraPosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
}
