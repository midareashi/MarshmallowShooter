using UnityEngine;

public class Joystick : MonoBehaviour
{
    public GameObject santa;
    public float speed;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    public Transform circle;
    public Transform outerCircle;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MovePlayer(direction);
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
            santa.GetComponent<Animator>().SetBool("IsTurning", true);
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            santa.GetComponent<Animator>().SetBool("IsTurning",false);
        }
    }

    void MovePlayer(Vector2 direction)
    {
        santa.transform.Translate(direction * (speed + santa.GetComponent<PlayerController>().speedBonusTemp) * Time.deltaTime);
    }
}
