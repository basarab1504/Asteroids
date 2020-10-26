using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private float bornTick;
    [SerializeField]
    private float lifetime;
    private Rigidbody2D rigidbody;

    public void Update()
    {
        if (Time.time > bornTick + lifetime)
        {
            gameObject.SetActive(false);
        }
    }

    public void Shoot(Vector3 direction, float force)
    {
        bornTick = Time.time;
        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
}
