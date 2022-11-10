
using UnityEngine;

public class TrackTarget : MonoBehaviour
{
    private GameObject santa;
    private float spawnTime;
    public float speed;
    public float trackTime;
    private bool keepTracking;
    private Vector3 finalTrackPos;
    private Rigidbody2D rb;
    public float rotateSpeed = 200f;

    private void Start()
    {
        santa = GameObject.FindGameObjectWithTag("Player");
        spawnTime = Time.time;
        keepTracking = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (keepTracking)
        {
            Vector2 direction = (Vector2)santa.transform.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, -transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = -transform.up * speed;
            keepTracking = Time.time <= spawnTime + trackTime;
        }
        else
        {
            transform.position += finalTrackPos * Time.deltaTime;
        }
    }
}
