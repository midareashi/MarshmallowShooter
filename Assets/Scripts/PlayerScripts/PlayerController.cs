using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Santa;
    private bool moveSantaToStart = false;
    private bool moveSantaOffScreen = false;
    
    private void Update()
    {
        if (moveSantaOffScreen)
        {
            Santa.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 30, 0), 0.3f);
            if (Santa.transform.position == Vector3.MoveTowards(transform.position, new Vector3(0, 30, 0), 0.3f))
            {
                moveSantaOffScreen = false;
            }
        }
        if (moveSantaToStart)
        {
            Santa.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -15, 0), 0.3f);
            if (Santa.transform.position == Vector3.MoveTowards(transform.position, new Vector3(0, -15, 0), 0.3f))
            {
                moveSantaToStart = false;
                Santa.GetComponent<Boundries>().isBound = true;
            }
        }
    }

    public void FlyOffScreen()
    {
        Santa.GetComponent<Boundries>().isBound = false;
        moveSantaOffScreen = true;
    }

    public void FlyToStart()
    {
        Santa.GetComponent<Boundries>().isBound = false;
        moveSantaToStart = true;
    }
}
