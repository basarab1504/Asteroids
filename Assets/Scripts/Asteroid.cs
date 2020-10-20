using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector3 direction;
    [SerializeField]
    private float speed = 10;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        direction = (Vector3.zero - transform.position).normalized;
    }

    public void Update()
    {
        rigidbody.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
