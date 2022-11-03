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
}
