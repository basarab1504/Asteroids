using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    [SerializeField]
    private Asteroid asteroidPrefab;
    [SerializeField]
    private float countToSpawn;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < countToSpawn; i++)
        {
            var a = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            a.PushRandom();
        }
    }
}
