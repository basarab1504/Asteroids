using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    private float bornTick;
    [SerializeField]
    private float lifetime;
    private Rigidbody2D rigidbody;

    public void Awake()
    {
        bornTick = Time.time;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Time.time > bornTick + lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(Vector3 direction, float force)
    {
        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
