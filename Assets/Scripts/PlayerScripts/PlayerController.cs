using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject Santa;
    private bool moveSanta = false;
    
    private void Update()
    {
        if (moveSanta)
        {
            Santa.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 30, 0), 0.3f);
        }
    }

    public void FlyOffScreen()
    {
        Santa.GetComponent<Boundries>().isBound = false;
        moveSanta = true;
    }
}
