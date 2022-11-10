using UnityEngine;

public class Boundries : MonoBehaviour
{
    private float objectWidth;
    private float objectHeight;

    public bool isBound;
    private Vector2 cameraPosition;

    void Start()
    {
        isBound = true;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void LateUpdate()
    {
        if (isBound)
        { 
            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, cameraPosition.x * -1 + objectWidth, cameraPosition.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, cameraPosition.y * -1 + objectHeight, cameraPosition.y - objectHeight);
            transform.position = viewPos;
        }
    }
}
