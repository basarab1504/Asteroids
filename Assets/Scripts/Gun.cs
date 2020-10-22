using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float lastCooldownTick;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float capacity;
    private float ammoCount;
    [SerializeField]
    private float gunForce;
    [SerializeField]
    private Ammo ammoPrefab;
    private Queue<float> ammosShotTicks;

    public void Shoot()
    {
        if (ammoCount > 0)
        {
            var ammo = Instantiate(ammoPrefab, transform.position, Quaternion.identity);
            ammo.Shoot(transform.up.normalized, gunForce);
            ammoCount--;
            ammosShotTicks.Enqueue(Time.time);
        }
    }

    private void Start()
    {
        ammoCount = capacity;
        ammosShotTicks = new Queue<float>();
    }

    void Update()
    {
        AmmoRestoring();
    }

    private void AmmoRestoring()
    {
        if (ammoCount < capacity)
        {
            if (Time.time > ammosShotTicks.Peek() + cooldown)
            {
                ammoCount++;
                ammosShotTicks.Dequeue();
            }
        }
    }
}
