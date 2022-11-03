using UnityEngine;

public class Boundries : MonoBehaviour
{
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, GameManager.CameraPosition.x * -1 + objectWidth, GameManager.CameraPosition.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, GameManager.CameraPosition.y * -1 + objectHeight, GameManager.CameraPosition.y - objectHeight);
        transform.position = viewPos;
    }
}
