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
    private float bulletCount;
    [SerializeField]
    private float laserForce;
    [SerializeField]
    private Bullet bulletPrefab;
    private Queue<float> bulletsShotTicks;

    private void Start()
    {
        bulletCount = capacity;
        bulletsShotTicks = new Queue<float>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        if (bulletCount < capacity)
        {
            if (Time.time > bulletsShotTicks.Peek() + cooldown)
            {
                bulletCount++;
                bulletsShotTicks.Dequeue();
            }
        }
    }

    void Shoot()
    {
        if (bulletCount > 0)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.Shoot(transform.up.normalized, laserForce);
            bulletCount--;
            bulletsShotTicks.Enqueue(Time.time);
        }
    }
}
