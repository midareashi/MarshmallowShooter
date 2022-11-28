using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Santa;
    public GameObject winScreen;
    public GameObject waveSpawner;
    public Animator animator;
    private bool moveSantaToStart = false;

    public float speedBonusTemp;
    public int damageBonusTemp;

    public float bonusTimeDuration;
    public float bonusStartTime;
    public bool hasBonus = false;
    public string bonusText;

    private void Update()
    {
        if (GetComponent<Vitals>().isDie)
        {
            animator.SetBool("IsDie", true);


            foreach (GameObject item in GameManager.allWeapons)
            {
                item.SetActive(false);
            }

            foreach (GameObject item in GameManager.allJetpacks)
            {
                item.SetActive(false);
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

        if (hasBonus)
        {
            if (Time.time > bonusStartTime + bonusTimeDuration)
            {
                hasBonus = false;
                bonusText = "";
                speedBonusTemp = 0;
                damageBonusTemp = 0;
            }
        }
    }

    public void FlyToStart()
    {
        moveSantaToStart = true;
    }

    public void destroyPlayer()
    {
        waveSpawner.GetComponent<WaveSpawner>().EndWave("lose");
    }
}
