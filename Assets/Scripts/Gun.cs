using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float lastCooldownTick;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private int capacity;
    private int ammoCount;
    private List<Ammo> ammo;
    [SerializeField]
    private float gunForce;
    [SerializeField]
    private Ammo ammoPrefab;
    private Queue<float> ammoShotTicks;

    public void Shoot()
    {
        if (ammoCount > 0)
        {
            var currentAmmo = ammo[capacity - ammoCount];
            currentAmmo.transform.position = transform.position;
            currentAmmo.gameObject.SetActive(true);
            currentAmmo.Shoot(transform.up.normalized, gunForce);
            ammoCount--;
            ammoShotTicks.Enqueue(Time.time);
        }
    }

    private void Start()
    {
        ammo = new List<Ammo>();
        ammoShotTicks = new Queue<float>();
        LoadGun();
    }

    void Update()
    {
        GunReloading();
    }

    private void LoadGun()
    {
        for (int i = 0; i < capacity; i++)
        {
            var ammo = Instantiate(ammoPrefab, transform.position, Quaternion.identity);
            ammo.gameObject.SetActive(false);
            this.ammo.Add(ammo);
            ammoCount++;
        }
    }

    private void GunReloading()
    {
        if (ammoCount < capacity)
        {
            if (Time.time > ammoShotTicks.Peek() + cooldown)
            {
                ammoCount++;
                ammoShotTicks.Dequeue();
            }
        }
    }

    private void OnDestoy()
    {
        foreach(var b in ammo)
            Destroy(b.gameObject);
    }
}
