
using UnityEngine;

public class TrackTarget : MonoBehaviour
{
    private GameObject santa;
    private float spawnTime;
    public float trackTime;
    private bool keepTracking;
    private Vector3 finalTrackPos;

    private void Start()
    {
        santa = GameObject.FindGameObjectWithTag("Player");
        spawnTime = Time.time;
        keepTracking = true;
    }

    private void Update()
    {
        if (keepTracking)
        {
            transform.position = Vector3.MoveTowards(transform.position, santa.transform.position, 0.3f);
            finalTrackPos = (santa.transform.position - transform.position).normalized * 4;
            keepTracking = Time.time <= spawnTime + trackTime;
        }
        else
        {
            transform.position += finalTrackPos * Time.deltaTime;
        }
    }
}
