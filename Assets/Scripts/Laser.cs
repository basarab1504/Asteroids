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
    [SerializeField]
    private LaserShot laserAmmoPrefab;
    private Queue<float> laserShotTicks;

    private void Start()
    {
        laserShotsCount = capacity;
        laserShotTicks = new Queue<float>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
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
            var laserShot = Instantiate(laserAmmoPrefab, transform.position, Quaternion.identity);
            laserShot.Shoot(transform.up.normalized, laserDistance);
            laserShotsCount--;
            laserShotTicks.Enqueue(Time.time);
        }
    }
}
