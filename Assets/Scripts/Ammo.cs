using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public class Ammo : MonoBehaviour, IAmmo, IPoolable
{
    private float bornTick;
    [SerializeField]
    private float lifetime;
    private Rigidbody2D rigidbody;

    public bool InUse => Time.time < bornTick + lifetime;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!InUse)
        {
            gameObject.SetActive(false);
        }
    }

    public void Shoot(Coordinates3D direction, float force)
    {
        bornTick = Time.time;
        gameObject.SetActive(true);
        rigidbody.AddForce(new Vector3(direction.X, direction.Y, direction.Z) * force, ForceMode2D.Impulse);
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    // private float bornTick;
    // [SerializeField]
    // private float lifetime;
    // private Rigidbody2D rigidbody;

    // public void Update()
    // {
    //     if (Time.time > bornTick + lifetime)
    //     {
    //         gameObject.SetActive(false);
    //     }
    // }

    // public void Shoot(Vector3 direction, float force)
    // {
    //     bornTick = Time.time;
    //     rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
    // }

    // private void Awake()
    // {
    //     rigidbody = GetComponent<Rigidbody2D>();
    // }
}
