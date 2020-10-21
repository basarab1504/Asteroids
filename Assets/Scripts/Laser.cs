using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float lastCooldownTick;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float capacity;
    private float laserShotsCount;
    [SerializeField]
    private float laserDistance;
    private Queue<float> laserShotTicks;

    private void Start()
    {
        laserShotsCount = capacity;
        laserShotTicks = new Queue<float>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        if (laserShotsCount < capacity)
        {
            if (Time.time > laserShotTicks.Peek() + cooldown)
            {
                laserShotsCount++;
                laserShotTicks.Dequeue();
            }
        }
    }

    void Shoot()
    {
        if (laserShotsCount > 0)
        {
            Debug.DrawRay(transform.position, transform.up * laserDistance, Color.red, 1);
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            int results = Physics2D.Raycast(transform.position, transform.up, new ContactFilter2D(), hits, laserDistance);
            foreach (var a in hits)
                Destroy(a.collider.gameObject);
            laserShotsCount--;
            laserShotTicks.Enqueue(Time.time);
        }
    }
}
