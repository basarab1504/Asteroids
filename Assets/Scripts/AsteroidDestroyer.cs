using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    [SerializeField]
    private Asteroid debrisPrefab;
    [SerializeField]
    private int countToSpawn;
    private Rigidbody2D rigidbody;
    private List<Asteroid> debris;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        debris = new List<Asteroid>(countToSpawn);
        FillDebrisList();
    }

    private void FillDebrisList()
    {
        for (int i = 0; i < countToSpawn; i++)
        {
            var a = Instantiate(debrisPrefab, transform.position, Quaternion.identity);
            a.gameObject.SetActive(false);
            debris.Add(a);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var d in debris)
        {
            d.gameObject.SetActive(true);
            d.PushRandom();
        }
    }
}
