using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject Santa;

    private void Start()
    {
        EquipSanta();
    }

    public void EquipSanta()
    {
    }

    public void FlyOffScreen()
    {
        this.GetComponent<Boundries>().isBound = false;
        Santa.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 30, 0), 1.0f);
    }
}
